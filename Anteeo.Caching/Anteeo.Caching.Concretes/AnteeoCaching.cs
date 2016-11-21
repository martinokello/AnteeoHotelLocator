using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using Anteeo.Caching.Anteeo.Caching.Interfaces;

namespace Anteeo.Caching.Anteeo.Caching.Concretes
{
    public class AnteeoCaching : IAnteeoCaching
    {
        private Cache _cache;

        public dynamic GetFromCache(string key)
        {
            return _cache[key];
        }

        public Cache CacheObject
        {
            set { _cache = value; }
            get { return _cache; }
        }
        public void StoreIntoCache(string key, dynamic value, int duration)
        {
            _cache.Add(key, value, null, DateTime.Now + TimeSpan.FromHours((double)duration), TimeSpan.FromHours(0),
                CacheItemPriority.Normal, null);
        }
        public AnteeoCaching() { }
    }
}
