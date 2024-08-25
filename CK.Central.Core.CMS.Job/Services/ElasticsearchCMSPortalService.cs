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
    public class ElasticsearchCMSJobService : ElasticsearchBaseService, IElasticsearchCMSJobService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchCMSJobService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
