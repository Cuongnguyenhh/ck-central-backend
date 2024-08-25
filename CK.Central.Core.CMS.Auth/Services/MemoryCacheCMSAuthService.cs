using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.Services
{
    public class MemoryCacheCMSAuthService : MemoryCacheBaseService, IMemoryCacheCMSAuthService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSAuthService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
