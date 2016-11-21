using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.IAuth;

namespace AnteeoAuthentication.AuthAbstracts
{
    public abstract class AuthenticationBase : IAuthenticator
    {
        protected AuthenticationTo AuthObject { get; set; }
        public abstract string GetToken(string authUrl, string username, string password);

        public DateTime ComputeExpirationTime()
        {
            return AuthObject.StartTime.AddHours(AuthObject.DurationOfAuthorization);
        }
    }
}
