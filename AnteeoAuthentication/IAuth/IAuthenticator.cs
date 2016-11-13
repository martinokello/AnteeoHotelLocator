using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnteeoAuthentication.IAuth
{
    public interface IAuthenticator
    {
        string GetToken(string authUrl, string username, string password);
    }
}
