using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;

namespace AnteeoAuthentication.AuthAbstracts
{
    public class AuthenticationBase
    {
        protected AuthenticationTo AuthObject{ get; set; }

        public virtual DateTime ComputeExpirationTime()
        {
            return DateTime.Now.AddHours(2);
        }
    }
}
