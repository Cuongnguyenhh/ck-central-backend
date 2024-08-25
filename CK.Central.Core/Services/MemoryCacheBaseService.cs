using CK.Central.Core.Abstract.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Services
{
    public abstract class MemoryCacheBaseService : IMemoryCacheBaseService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheBaseService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public T GetData<T>(string key)
        {
            T item = (T)_memoryCache.Get(key)
;
            return item;
        }
        public bool SetData<T>(string key, T value, MemoryCacheEntryOptions cacheEntryOptions)
        {
            bool res = true;
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _memoryCache.Set(key, value, cacheEntryOptions);
                }
            }
            catch{}

            return res;
        }
        public void RemoveData(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
