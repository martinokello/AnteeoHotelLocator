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

        public HomeController()
        {
            _cachingService = new AnteeoCaching(null,Int32.Parse(ConfigHelper.CachingDuration));
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
            
            _hotelService = new HotelAndLocationService<dynamic[]>();
            
            var cachingHours = 0;
            var CacheTokenKey = "TokenKey";
            int.TryParse(ConfigHelper.CachingDuration, out cachingHours);

            _cachingService = new AnteeoCaching(HttpContext.Cache, cachingHours);
            var authObject = new AuthenticationTo
            {
                DurationOfAuthorization = cachingHours,
                Username = ConfigHelper.UserName,
                Password = ConfigHelper.Password,
                TimeSpanValidForUnits = AnteeoTimeUnits.Hours
            };
            //_authService = new AnteeoHotelLocatorAuth(_hotelService, authObject);

            var resultTokenContent = _cachingService.GetFromCache(CacheTokenKey);
            if (resultTokenContent == null || DateTime.Now <= _authService.ComputeExpirationTime())
            {
                resultTokenContent = _authService.GetToken(ConfigHelper.AuthUrl, authObject.Username, authObject.Password);
                _cachingService.StoreIntoCache(CacheTokenKey, resultTokenContent, cachingHours);
                authObject.StartTime = DateTime.Now;
                authObject.Token = resultTokenContent;
            }
            var tokenUnit = resultTokenContent.Split(new[] {' '});
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