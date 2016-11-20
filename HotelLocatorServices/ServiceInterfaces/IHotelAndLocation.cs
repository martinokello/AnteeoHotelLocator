using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;

namespace HotelLocatorServices.ServiceInterfaces
{
    public interface IHotelAndLocation
    {
        dynamic[] GetAllHotelAndLocationData(string url, IDictionary<string, string> queryParameters, string token);
        ResponseMessage Ping(string url, RequestMessage message, ModeType modeType);
        string TmsToken { get; set; }
    }
}
