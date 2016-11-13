using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public class Country
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public IList<Resort> Resorts { get; set; } 
    }
}
