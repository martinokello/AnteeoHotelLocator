using System;
using System.Web.UI.WebControls;
using AnteeoXMLEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnteeoHotelLocator.Tests
{
    [TestClass]
    public class AnteeoXLEngineTest
    {
        private string xml = @"<ApiHotelAndLocationQueryResponse xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
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
                              </Regions>
                            </ApiHotelAndLocationQueryResponse>";
        [TestMethod]
        public void Test_AnteeoXMLEngine_ParseFromXmlString_Passes_Parsing()
        {
            var regions = AnteeoXmlHelper.ParseFromXmlString(xml);

            Assert.AreEqual(regions.Count, 2);
        }
    }
}
