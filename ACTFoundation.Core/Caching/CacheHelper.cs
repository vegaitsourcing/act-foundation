using System;
using System.Linq;
using System.Runtime.Caching;

namespace ACTFoundation.Core.Caching
{
    /// <summary>
    /// Thread Safe Singleton Cache Class
    /// </summary>
    public sealed class CacheHelper
    {
        private const string CacheName = "ACTFoundationCache";
        private const double SettingCacheExpirationTimeInMinutes = 120d; // 120 minutes

        private static volatile CacheHelper _instance; //  Locks var until assignment is complete for double safety
        private static MemoryCache _memoryCache;
        private static readonly object syncRoot = new object();
        private CacheHelper() { }

        /// <summary>
        /// Singleton Cache Instance
        /// </summary>
        public static CacheHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            InitializeInstance();

                        }
                    }
                }
                return _instance;
            }
        }

        private static void InitializeInstance()
        {
            _instance = new CacheHelper();
            _memoryCache = new MemoryCache(CacheName);
        }

        /// <summary>
        /// Writes Key Value Pair to Cache
        /// </summary>
        /// <param name="key">Key to associate Value with in Cache</param>
        /// <param name="value">Value to be stored in Cache associated with Key</param>
        public void Write(string key, object value)
        {
            _memoryCache.Add(key, value, DateTimeOffset.Now.AddMinutes(SettingCacheExpirationTimeInMinutes));
        }

        /// <summary>
        /// Writes Key Value Pair to Cache
        /// </summary>
        /// <param name="key">Key to associate Value with in Cache</param>
        /// <param name="value">Value to be stored in Cache associated with Key</param>
        public void Write(string key, object value, DateTimeOffset offset)
        {
            _memoryCache.Add(key, value, offset);
        }

        /// <summary>
        /// Returns Value stored in Cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value stored in cache</returns>
        public object Read(string key)
        {
            return _memoryCache.Get(key);
        }

        /// <summary>
        /// Returns Value stored in Cache, null if non existent
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Value stored in cache</returns>
        public object TryRead(string key)
        {
            try
            {
                return _memoryCache.Get(key);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public bool Contains(string key)
        {
            return _memoryCache.Contains(key);
        }

        public string[] GetAllKeys()
        {
            return _memoryCache.Select(x => x.Key).ToArray();
        }

        public void Invalidate(string key)
        {
            if (Contains(key))
                _memoryCache.Remove(key);
        }
    }
}
