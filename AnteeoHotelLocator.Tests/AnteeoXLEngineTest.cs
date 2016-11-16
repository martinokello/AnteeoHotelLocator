using System;
using System.Runtime.InteropServices;
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
        [TestMethod]
        public void Test_AnteeoXMLEngine_ParseFromXmlString_Passes_Parsing()
        {
            var regions = AnteeoXmlHelper.ParseFromXmlString(xml);

            var region1 = regions[0];
            var region2 = regions[1];
            var countriesInReg1 = region1.Countries;
            var countriesInReg2 = region2.Countries;
            var resortsInReg1 = countriesInReg1[0].Resorts;
            var resortsInReg2 = countriesInReg2[1].Resorts;
            var hotelsInReg1 = resortsInReg1[0].Hotels;
            var hotelsInReg2 = resortsInReg1[1].Hotels;
            var airportsInReg1 = resortsInReg2[0].Airports;
            var airportsInReg2 = resortsInReg2[1].Airports;


            //Regions
            Assert.AreEqual(regions.Count, 2);
            Assert.IsNotNull(region1.Name);
            Assert.IsNotNull(region2.Name);
            Assert.IsNotNull(region1.RegionCode);


            //Countries
            Assert.AreEqual(countriesInReg1.Count, 2);
            Assert.AreEqual(countriesInReg2.Count, 2);
            Assert.IsNotNull(countriesInReg1[0].Name);
            Assert.IsNotNull(countriesInReg2[1].Name);
            Assert.IsNotNull(countriesInReg1[0].CountryCode);
            Assert.IsNotNull(countriesInReg2[1].CountryCode);

            //Resorts

            Assert.AreEqual(resortsInReg1.Count, 2);
            Assert.AreEqual(resortsInReg2.Count, 2);
            Assert.IsNotNull(resortsInReg1[0].Name);
            Assert.IsNotNull(resortsInReg2[1].Name);
            Assert.IsNotNull(resortsInReg1[0].ResortCode);
            Assert.IsNotNull(resortsInReg2[1].ResortCode);


            //Hotels

            Assert.AreEqual(hotelsInReg1.Count, 2);
            Assert.AreEqual(hotelsInReg2.Count, 2);
            Assert.IsNotNull(hotelsInReg1[0].Name);
            Assert.IsNotNull(hotelsInReg2[1].Name);
            Assert.IsNotNull(hotelsInReg1[0].HotelCode);
            Assert.IsNotNull(hotelsInReg2[1].HotelCode);


            //Airports

            Assert.AreEqual(airportsInReg1.Count, 2);
            Assert.AreEqual(airportsInReg2.Count, 2);
            Assert.IsNotNull(airportsInReg1[0].Name);
            Assert.IsNotNull(airportsInReg2[1].Name);
            Assert.IsNotNull(airportsInReg1[0].AirportCode);
            Assert.IsNotNull(airportsInReg1[1].AirportCode);
        }
    }
}
