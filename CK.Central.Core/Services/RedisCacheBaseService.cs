using CK.Central.Core.Abstract.Services;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using StackExchange.Redis.Extensions.Newtonsoft;

namespace CK.Central.Core.Services
{
    public abstract class RedisCacheBaseService : IRedisCacheBaseService
    {
        private IDatabase _cachedb;
        private readonly IConfiguration _configuration;
        public RedisCacheBaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            string? host = _configuration.GetSection("RedisServer:Host").Value;
            string? port = _configuration.GetSection("RedisServer:Port").Value;
            bool isConnect = true;

            try { ConnectionMultiplexer.Connect(host + ":" + port); } catch { isConnect = false; }

            if (isConnect)
            {
                var redis = CreateInstance();
                _cachedb = redis.GetDatabase();
            }
        }
        private ConnectionMultiplexer CreateInstance()
        {
            string? host = _configuration.GetSection("RedisServer:Host").Value;
            string? port = _configuration.GetSection("RedisServer:Port").Value;
            return ConnectionMultiplexer.Connect(host + ":" + port);
        }

        public async Task<T> GetData<T>(string key)
        {
            var value = await _cachedb.StringGetAsync(key)
;
            if (!string.IsNullOrEmpty(value))
            {
                return JsonSerializer.Deserialize<T>(value);
            }
            return default;
        }

        public async Task<object> RemoveData(string key)
        {
            var _exist = await _cachedb.KeyExistsAsync(key)
;
            if (_exist)
            {
                return _cachedb.KeyDelete(key)
;
            }
            return false;
        }

        public async Task<bool> SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expiretyTime = expirationTime.DateTime.Subtract(DateTime.Now);
            return await _cachedb.StringSetAsync(key, JsonSerializer.Serialize(value), expiretyTime);
        }

        public async Task<bool> SetData<T>(string key, T value)
        {
            return await _cachedb.StringSetAsync(key, JsonSerializer.Serialize(value));
        }
    }
}
