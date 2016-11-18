using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnteeoHotelLocator
{
    public class ConfigHelper
    {

        public static string AuthUrl = System.Configuration.ConfigurationManager.AppSettings["AnteeoAuthorizationUrl"];
        public static string HotelServiceEndpointUrl = System.Configuration.ConfigurationManager.AppSettings["AnteeoReigonalLocationsUrl"];
        public static string CachingDuration = System.Configuration.ConfigurationManager.AppSettings["CacheDurationInHours"];
        public static string UserName = System.Configuration.ConfigurationManager.AppSettings["UserName"];
        public static string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];
    }
}