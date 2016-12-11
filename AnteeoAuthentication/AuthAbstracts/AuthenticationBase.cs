using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.IAuth;

namespace AnteeoAuthentication.AuthAbstracts
{
    public abstract class AuthenticationBase : IAuthenticator, ITiming
    {
        protected AuthenticationTo AuthObject { get; set; }
        public abstract string GetToken(string authUrl, string username, string password);
        public virtual DateTime ComputeExpirationTime()
        {
            return AuthObject.StartTime.AddHours(AuthObject.DurationOfAuthorization);
        }
    }

    public interface ITiming
    {
        DateTime ComputeExpirationTime();
    }
}
