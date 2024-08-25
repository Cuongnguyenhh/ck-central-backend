using CK.Central.Core.CMS.Portal.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Portal.Services
{
    public class MemoryCacheCMSPortalService : MemoryCacheBaseService, IMemoryCacheCMSPortalService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSPortalService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
