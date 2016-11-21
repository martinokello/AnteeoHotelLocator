using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Anteeo.Caching.Anteeo.Caching.Interfaces
{
    public interface IAnteeoCaching
    {
        dynamic GetFromCache(string key);
        void StoreIntoCache(string key, dynamic value, int duration);
        Cache CacheObject { get; set; }
    }
}
