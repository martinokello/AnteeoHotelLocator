using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Configuration;
using System.Configuration.Internal;
using Anteeo.Caching.Anteeo.Caching.Concretes;
using Anteeo.Caching.Anteeo.Caching.Interfaces;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.AuthAbstracts;
using AnteeoAuthentication.AuthenticationConcretes;
using HotelLocatorServices.ServiceInterfaces;
using HotelLocatorServices.ConcreteServices;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Practices.Unity;

namespace AnteeoHotelLocator.Controllers
{
    public class HomeController : Controller
    {
        private IAnteeoCaching _cachingService;
        private IHotelAndLocation<dynamic[]> _hotelService;
        private AnteeoHotelLocatorAuth _authService;
        private int cachingHours = 0;
        private const string cacheTokenKey = "TokenKey";

        public HomeController()
        {
            int.TryParse(ConfigHelper.CachingDuration, out cachingHours);

            _cachingService = new AnteeoCaching(null, Int32.Parse(ConfigHelper.CachingDuration));
            _authService = new AnteeoHotelLocatorAuth(new HotelAndLocationService<dynamic[]>(), new AuthenticationTo());
            _hotelService = new HotelAndLocationService<dynamic[]>();
        }
        [InjectionConstructor]
        public HomeController(AnteeoHotelLocatorAuth authService, IHotelAndLocation<dynamic[]> hotelService,
            IAnteeoCaching cachingService)
        {
            _cachingService = cachingService;
            _authService = authService;
            _hotelService = hotelService;
        }
        public ActionResult Index()
        {
            (_cachingService as AnteeoCaching).CacheObject = HttpContext.Cache;

            _hotelService = new HotelAndLocationService<dynamic[]>();
            
            var authObject = new AuthenticationTo
            {
                DurationOfAuthorization = cachingHours,
                Username = ConfigHelper.UserName,
                Password = ConfigHelper.Password,
                TimeSpanValidForUnits = AnteeoTimeUnits.Hours
            };

            var resultTokenContent = _cachingService.GetFromCache(cacheTokenKey);
            if (resultTokenContent == null || DateTime.Now <= _authService.ComputeExpirationTime())
            {
                resultTokenContent = GetAuthToken(authObject, cacheTokenKey, cachingHours);
            }
            var tokenUnit = resultTokenContent.Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries);
            if (tokenUnit.Length > 1)
            {
                //Errored: MESSEGE in content
                ViewBag.Exception = "Exception: Failed Authorization: " + resultTokenContent;
                return View();
            }
            else if (tokenUnit.Length == 1)
            {
                var queryParams = new Dictionary<string, string>();

                queryParams.Add("username",authObject.Username);
                queryParams.Add("password",authObject.Password);
                dynamic[] listOfRegions = _hotelService.GetAllHotelAndLocationData(ConfigHelper.HotelServiceEndpointUrl, queryParams, resultTokenContent);

                if (listOfRegions[0] == null)
                {
                    ViewBag.Exception = "Exception: Failed Authorization: " /*+ (string)listOfRegions[0]*/;
                    return View();
                }
                return View((Region[])listOfRegions);
            }

            return View();
        }

        private string GetAuthToken(AuthenticationTo authObject,string cacheTokenKey, int cachingHours)
        {
            var resultTokenContent = _authService.GetToken(ConfigHelper.AuthUrl, authObject.Username, authObject.Password);
            _cachingService.StoreIntoCache(cacheTokenKey, resultTokenContent, cachingHours);
            authObject.StartTime = DateTime.Now;
            authObject.Token = resultTokenContent;
            return resultTokenContent;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}