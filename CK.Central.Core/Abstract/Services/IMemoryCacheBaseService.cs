using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IMemoryCacheBaseService
    {
        /// <summary>
        /// Get Data using key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetData<T>(string key);

        /// <summary>
        /// Set Data with Value and Expiration Time of Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        bool SetData<T>(string key, T value, MemoryCacheEntryOptions cacheEntryOptions);

        /// <summary>
        /// Remove Data
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        void RemoveData(string key);
    }
}
