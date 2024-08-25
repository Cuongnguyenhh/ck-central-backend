using CK.Central.Core.CMS.Job.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Job.Services
{
    public class RedisCacheCMSJobService : RedisCacheBaseService, IRedisCacheCMSJobService
    {
        private readonly IConfiguration _configuration;
        public RedisCacheCMSJobService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
