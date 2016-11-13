using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public class Resort
    {

        public string ResortCode { get; set; }
        public string Name { get; set; }
        public IList<Hotel> Hotels { get; set; }
        public IList<Airport> Airports { get; set; }
    }
}
