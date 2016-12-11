using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnteeoHotelLocator
{
    public class ConfigHelper:IConfig
    {
        private string authUrl;
        private string hotelServiceEndpointUrl;
        private string cachingDuration;
        private string userName;
        private string password;
        public string AuthUrl
        {
            get
            {return System.Configuration.ConfigurationManager.AppSettings["AnteeoAuthorizationUrl"]; }
            set { authUrl = value; }
        }
        public string HotelServiceEndpointUrl
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["AnteeoReigonalLocationsUrl"]; }
            set { hotelServiceEndpointUrl = value; }
        }
        public string CachingDuration
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["CacheDurationInHours"]; }
            set { cachingDuration = value; }
        }
        public string UserName
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["UserName"];  }
            set { userName = value; }
        }
        public string Password
        {
            get
            { return System.Configuration.ConfigurationManager.AppSettings["Password"];  }
            set { password = value; }
        }

    }

    public interface IConfig
    {
        string AuthUrl { get; set; }
        string HotelServiceEndpointUrl { get; set; }
        string CachingDuration { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}