using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.MasterData.Services
{
    public class MemoryCacheCMSMasterDataService : MemoryCacheBaseService, IMemoryCacheCMSMasterDataService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheCMSMasterDataService(IMemoryCache memoryCache) : base(memoryCache) => this._memoryCache = memoryCache;
    }
}
