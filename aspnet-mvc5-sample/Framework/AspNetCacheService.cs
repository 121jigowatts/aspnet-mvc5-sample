using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace aspnet_mvc5_sample.Framework
{
    public class AspNetCacheService : ICacheService
    {
        private readonly Cache _aspnetCache;
        public AspNetCacheService()
        {
            if (HttpContext.Current != null)
            {
                _aspnetCache = HttpContext.Current.Cache;
            }
        }

        public object Get(string key)
        {
            return _aspnetCache[key];
        }

        public void Set(string key, object data)
        {
            _aspnetCache[key] = data;
        }

        public object this[string key]
        {
            get
            {
                return _aspnetCache[key];
            }

            set
            {
                _aspnetCache[key] = value;
            }
        }

    }
}