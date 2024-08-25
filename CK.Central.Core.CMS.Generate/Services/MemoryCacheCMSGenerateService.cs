using CK.Central.Core.CMS.Generate.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Generate.Services
{
    public class MemoryCacheCMSGenerateService : MemoryCacheBaseService, IMemoryCacheCMSGenerateService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSGenerateService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
