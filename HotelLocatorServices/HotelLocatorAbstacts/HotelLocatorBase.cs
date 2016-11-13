using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;

namespace HotelLocatorServices.HotelLocatorAbstacts
{
    public abstract class HotelLocatorBase
    {
        protected abstract ResponseMessage Request(RequestMessage message,HttpMethod method);
    }
}
