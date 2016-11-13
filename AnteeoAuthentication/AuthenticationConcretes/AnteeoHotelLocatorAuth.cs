using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.AuthAbstracts;
using AnteeoAuthentication.IAuth;
using HotelLocatorServices.ConcreteServices;
using HotelLocatorServices.ServiceInterfaces;

namespace AnteeoAuthentication.AuthenticationConcretes
{
    public class AnteeoHotelLocatorAuth: AuthenticationBase,IAuthenticator
    {
        private AuthenticationTo _authenticationTo;
        private IHotelAndLocation<dynamic[]> _authService;

        public AnteeoHotelLocatorAuth(IHotelAndLocation<dynamic[]> authService, AuthenticationTo authenticationTo)
        {
            _authService = authService;
            _authenticationTo = authenticationTo;
        }
        public override DateTime ComputeExpirationTime()
        {
           return _authenticationTo.StartTime + TimeSpan.FromHours(_authenticationTo.DurationOfAuthorization);
        }

        public string GetToken(string authUrl, string username, string password)
        {
            _authenticationTo.Username = username;
            _authenticationTo.Password = password;

            return Authenticate(authUrl).Content[0];
        }

        public ResponseMessage Authenticate(string url)
        {
            var queryString = string.Format("?username={0}&password={1}", _authenticationTo.Username,
                _authenticationTo.Password);
            var message = new RequestMessage();

            return _authService.Ping(url + queryString, message);
        }
    }
}
