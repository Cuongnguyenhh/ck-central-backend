using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IRedisCacheBaseService
    {
        Task<T> GetData<T>(string key);
        Task<bool> SetData<T>(string key, T value);
        Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime);
        Task<object> RemoveData(string key);
    }
}
