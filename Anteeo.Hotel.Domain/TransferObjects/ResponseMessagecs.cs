using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public class ResponseMessage
    {
        public string Version { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public dynamic[] Content { get; set; }
    }
}
