using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.Mvc;
using Anteeo.Caching.Anteeo.Caching.Interfaces;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.AuthAbstracts;
using AnteeoAuthentication.IAuth;
using AnteeoHotelLocator.Controllers;
using AnteeoXMLEngine;
using HotelLocatorServices.ServiceInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnteeoHotelLocator.Tests
{
    [TestClass]
    public class HomeControllerTest
    {


        private Mock<IAnteeoCaching> cachingServiceMoq;
        private Mock<AuthenticationBase> authServiceMoq;
        private Mock<IHotelAndLocation> hotelServiceMoq;
        private Mock<IConfig> configServiceMoq;

        [TestInitialize]
        public void SetUp()
        {
            cachingServiceMoq = new Mock<IAnteeoCaching>();
            authServiceMoq = new Mock<AuthenticationBase>();
            hotelServiceMoq = new Mock<IHotelAndLocation>();
            configServiceMoq = new Mock<IConfig>();

            hotelServiceMoq.Setup(p => p.TmsToken).Returns(It.IsAny<string>());
            hotelServiceMoq.Setup(p => p.Ping(It.IsAny<string>(), It.IsAny<RequestMessage>(), ModeType.Request));
            hotelServiceMoq.Setup(
                p =>
                    p.GetAllHotelAndLocationData(It.IsAny<string>(), new Dictionary<string, string>(),
                        It.IsAny<string>())).Returns(AnteeoXmlHelper.ParseFromXmlString(AnteeoFakeCach.xmlCacheValue).ToArray()); 

            cachingServiceMoq.Setup(p => p.GetCacheObject()).Returns(new Cache());
            cachingServiceMoq.Setup(p => p.SetCacheObject(new Cache()));
            cachingServiceMoq.Setup(p => p.GetFromCache(It.IsAny<string>())).Returns("Token");
            cachingServiceMoq.Setup(p => p.StoreIntoCache(It.IsAny<string>(),It.IsAny<object>(),It.IsAny<int>()));

            authServiceMoq.Setup(p => p.ComputeExpirationTime()).Returns(It.Is<DateTime>(p=> p == DateTime.Now.AddMinutes(4)));
            authServiceMoq.Setup(p => p.GetToken(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(It.IsAny<string>());

            configServiceMoq.Setup(p => p.AuthUrl).Returns(It.IsAny<string>());
            configServiceMoq.Setup(p => p.CachingDuration).Returns(It.IsAny<int>().ToString());
            configServiceMoq.Setup(p => p.HotelServiceEndpointUrl).Returns(It.IsAny<string>());
            configServiceMoq.Setup(p => p.Password).Returns(It.IsAny<string>());
            configServiceMoq.Setup(p => p.UserName).Returns(It.IsAny<string>());

        }
        [TestMethod]
        public void Test_Home_IndexAction_Returns_ProperView_With_Dependencies()
        {
            var homeController = new HomeController(authServiceMoq.Object, hotelServiceMoq.Object, cachingServiceMoq.Object,configServiceMoq.Object);

            var view = (ViewResult) homeController.Index();

            Assert.IsNotNull(view.Model);
        }
   
    }
    
    public class AnteeoFakeCach : IAnteeoCaching
    {
        private Cache _cacheObject;
        public dynamic GetFromCache(string key)
        {
            return AnteeoFakeCach.xmlCacheValue;
        }

        public void StoreIntoCache(string key, dynamic value, int duration)
        {
            
        }

        public Cache GetCacheObject (){return new System.Web.Caching.Cache(); }
        public void SetCacheObject(Cache cacheObject)
        {
            _cacheObject = cacheObject;
        }

        public static string xmlCacheValue  = @"<ApiHotelAndLocationQueryResponse xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
                              <Regions>
                                <Region>
                                  <Countries>
                                    <Country>
                                      <CountryCode>sample string 1</CountryCode>
                                      <Name>sample string 2</Name>
                                      <Resorts>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                      </Resorts>
                                    </Country>
                                    <Country>
                                      <CountryCode>sample string 1</CountryCode>
                                      <Name>sample string 2</Name>
                                      <Resorts>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                      </Resorts>
                                    </Country>
                                  </Countries>
                                  <Name>sample string 2</Name>
                                  <RegionCode>sample string 1</RegionCode>
                                </Region>
                                <Region>
                                  <Countries>
                                    <Country>
                                      <CountryCode>sample string 1</CountryCode>
                                      <Name>sample string 2</Name>
                                      <Resorts>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                      </Resorts>
                                    </Country>
                                    <Country>
                                      <CountryCode>sample string 1</CountryCode>
                                      <Name>sample string 2</Name>
                                      <Resorts>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                        <Resort>
                                          <Airports>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                            <Airport>
                                              <AirportCode>sample string 1</AirportCode>
                                              <Name>sample string 2</Name>
                                            </Airport>
                                          </Airports>
                                          <Hotels>
                                            <Hotel>
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                            <Hotel>\
                                              <HotelCode>sample string 1</HotelCode>
                                              <Name>sample string 2</Name>
                                            </Hotel>
                                          </Hotels>
                                          <Name>sample string 1</Name>
                                          <ResortCode>sample string 2</ResortCode>
                                        </Resort>
                                      </Resorts>
                                    </Country>
                                  </Countries>
                                  <Name>sample string 2</Name>
                                  <RegionCode>sample string 1</RegionCode>
                                </Region>
                              </Regions>
                            </ApiHotelAndLocationQueryResponse>";
    }
}
