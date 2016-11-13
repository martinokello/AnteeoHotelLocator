using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public class RequestMessage
    {
        public object[] Content { get; set; }
        public HttpMethod HttpMethod{get;set;}
        public Dictionary<string, string> Headers { get; set; }
        public string QueryString { get; set; }
        public string Token { get; set; }
    }
}
