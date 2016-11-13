using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anteeo.Hotel.Domain.TransferObjects
{
    public class Region
    {
        public string Name { get; set; }
        public string RegionCode { get; set; }
        public IList<Country> Countries { get; set; }
    }
}
