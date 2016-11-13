using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using Anteeo.Caching.Anteeo.Caching.Interfaces;

namespace Anteeo.Caching.Anteeo.Caching.Concretes
{
    public class AnteeoCaching : IAnteeoCaching
    {
        private Cache _cache;
        private int _cacheDuration;

        public dynamic GetFromCache(string key)
        {
            return _cache[key];
        }

        public void StoreIntoCache(string key, dynamic value, int duration)
        {
            _cache.Add(key, value, null, DateTime.Now + TimeSpan.FromHours((double)duration), TimeSpan.FromHours(0),
                CacheItemPriority.Normal, null);
        }

        public AnteeoCaching(Cache cache, int cacheDuration)
        {
            _cache = cache;
            _cacheDuration = cacheDuration;
        }

    }
}
