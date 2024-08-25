using CK.Central.Core.CMS.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Services
{
    public class RedisCacheCMSService : RedisCacheBaseService, IRedisCacheCMSService
    {
        private readonly IConfiguration _configuration;

        public RedisCacheCMSService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
