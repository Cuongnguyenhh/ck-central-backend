using CK.Central.Core.CMS.Authentication.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Authentication.Services
{
    public class MemoryCacheCMSAuthenticationService : MemoryCacheBaseService, IMemoryCacheCMSAuthenticationService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSAuthenticationService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
