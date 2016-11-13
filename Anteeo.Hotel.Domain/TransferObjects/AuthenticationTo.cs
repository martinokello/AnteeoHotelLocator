using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public enum AnteeoTimeUnits
    {
        Hours,
        Minutes,
        Seconds
    };

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    };

    public class AuthenticationTo
    {
        public DateTime StartTime { get; set; }
        public AnteeoTimeUnits TimeSpanValidForUnits { get; set; }
        public int DurationOfAuthorization { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
