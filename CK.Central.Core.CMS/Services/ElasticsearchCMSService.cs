using CK.Central.Core.CMS.Abstract.Services;
using CK.Central.Core.Services;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CK.Central.Core.CMS.DbContexts;

namespace CK.Central.Core.CMS.Services
{
    public class ElasticsearchCMSService : ElasticsearchBaseService, IElasticsearchCMSService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchCMSService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
