using CK.Central.Core.CMS.Generate.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Generate.Services
{
    public class ElasticsearchCMSGenerateService : ElasticsearchBaseService, IElasticsearchCMSGenerateService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchCMSGenerateService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
