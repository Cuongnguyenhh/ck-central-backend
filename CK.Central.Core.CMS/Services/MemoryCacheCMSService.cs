using CK.Central.Core.CMS.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Services
{
    public class MemoryCacheCMSService : MemoryCacheBaseService, IMemoryCacheCMSService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
