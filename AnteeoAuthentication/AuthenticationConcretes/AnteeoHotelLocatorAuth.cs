using System;
using Anteeo.Hotel.Domain.TransferObjects;
using AnteeoAuthentication.AuthAbstracts;
using HotelLocatorServices.ServiceInterfaces;

namespace AnteeoAuthentication.AuthenticationConcretes
{
    public class AnteeoHotelLocatorAuth: AuthenticationBase
    {
        private AuthenticationTo _authenticationTo;
        private IHotelAndLocation _authService;

        public AnteeoHotelLocatorAuth()
        {
            
        }
        public AnteeoHotelLocatorAuth(IHotelAndLocation authService, AuthenticationTo authenticationTo)
        {
            _authService = authService;
            _authenticationTo = authenticationTo;
        }
        public DateTime ComputeExpirationTime()
        {
           return _authenticationTo.StartTime + TimeSpan.FromHours(_authenticationTo.DurationOfAuthorization);
        }

        public override string GetToken(string authUrl, string username, string password)
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

            return _authService.Ping(url + queryString, message,ModeType.Authentication);
        }
    }
}
