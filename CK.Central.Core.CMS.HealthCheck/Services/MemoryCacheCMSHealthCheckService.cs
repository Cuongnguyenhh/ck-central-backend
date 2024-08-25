using CK.Central.Core.CMS.HealthCheck.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.HealthCheck.Services
{
    public class MemoryCacheCMSHealthCheckService : MemoryCacheBaseService, IMemoryCacheCMSHealthCheckService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSHealthCheckService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
