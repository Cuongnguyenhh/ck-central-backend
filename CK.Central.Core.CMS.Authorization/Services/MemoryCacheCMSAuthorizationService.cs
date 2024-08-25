using CK.Central.Core.CMS.Authorization.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Authorization.Services
{
    public class MemoryCacheCMSAuthorizationService : MemoryCacheBaseService, IMemoryCacheCMSAuthorizationService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSAuthorizationService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
