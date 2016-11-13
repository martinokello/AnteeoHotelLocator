using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using Anteeo.Hotel.Domain.TransferObjects;

namespace AnteeoXMLEngine
{
    public class AnteeoXmlHelper
    {
        public static IList<Region> ParseFromXmlString(string docStr)
        {
            /////////////////////////////////////////////////////////////////////////////////////
            //Requires Refactoring!! No time to do this                                    //////
            //to many if statements (separate logic into finer grained functions - no time///////
            /////////////////////////////////////////////////////////////////////////////////////
            var docx = XDocument.Parse(docStr);

            var regions = docx.Root.Descendants("Region");
            var responseObject = new ResponseMessage();
            var regionsList = new List<Region>();

            if (regions.Any())
            {
                var hotelsList = new List<Hotel>();
                var airportsList = new List<Airport>();
                var resortsList = new List<Resort>();
                var countriesList = new List<Country>();

                foreach (var region in regions)
                {
                    var rgCodeNode = region.Descendants("RegionCode").FirstOrDefault();
                    var nmrgName = region.Descendants("Name").FirstOrDefault();
                    Region regionObject = null;
                    if (rgCodeNode != null && nmrgName != null)
                    {
                        regionObject = new Region {RegionCode = rgCodeNode.Value, Name = nmrgName.Value};
                        regionsList.Add(regionObject);
                        regionObject.Countries = countriesList;
                    }
                    var countries = region.Descendants("Country");
                    foreach (var country in countries)
                    {
                        var ctCodeNode = country.Descendants("CountryCode").FirstOrDefault();
                        var nmcName = country.Descendants("Name").FirstOrDefault();
                        Country countryObject = null;
                        if (nmcName != null && ctCodeNode != null)
                        {
                            countryObject = new Country {CountryCode = ctCodeNode.Value, Name = nmcName.Value};
                            countriesList.Add(countryObject);
                            countryObject.Resorts = resortsList;
                        }
                        var resorts = country.Descendants("Resorts");
                        if (resorts.Any())
                        {
                            foreach (var resort in resorts)
                            {
                                var rsCodeNode = resort.Descendants("ResortCode").FirstOrDefault();
                                var nmrName = resort.Descendants("Name").FirstOrDefault();
                                Resort resortObject = null;
                                if (rsCodeNode != null && nmrName != null)
                                {
                                    resortObject = new Resort { ResortCode = rsCodeNode.Value, Name = nmrName.Value };
                                    resortsList.Add(resortObject);
                                    resortObject.Airports = airportsList;
                                    resortObject.Hotels = hotelsList;
                                }
                                var airportsEnvelope = resort.Descendants("Airports").FirstOrDefault();
                                var hotelsEnvelope = resort.Descendants("Hotels").FirstOrDefault();
                                if (airportsEnvelope != null)
                                {
                                    var airports = airportsEnvelope.Descendants("Airport"); 
                                    if (airports.Any())
                                    {
                                        foreach (var airport in airports)
                                        {
                                            var apCodeNode = airport.Descendants("AirportCode").FirstOrDefault();
                                            var nmaName = airport.Descendants("Name").FirstOrDefault();
                                            if (apCodeNode != null && nmaName != null)
                                            {
                                                airportsList.Add(new Airport { AirportCode = apCodeNode.Value, Name = nmaName.Value });
                                            }
                                        }
                                    }
                                }
                                if (hotelsEnvelope != null)
                                {
                                    var hotels = hotelsEnvelope.Descendants("Hotel");
                                    if (hotels.Any())
                                    {
                                        foreach (var hotel in hotels)
                                        {
                                            var htCodeNode = hotel.Descendants("HotelCode").FirstOrDefault();
                                            var htgName = hotel.Descendants("Name").FirstOrDefault();
                                            if (htCodeNode != null && htgName != null)
                                            {
                                                hotelsList.Add(new Hotel { HotelCode = htCodeNode.Value, Name = htgName.Value });
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            return regionsList;
        }
    }
}
