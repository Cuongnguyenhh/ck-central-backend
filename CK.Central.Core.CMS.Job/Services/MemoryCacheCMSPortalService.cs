using CK.Central.Core.CMS.Job.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Job.Services
{
    public class MemoryCacheCMSJobService : MemoryCacheBaseService, IMemoryCacheCMSJobService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSJobService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
