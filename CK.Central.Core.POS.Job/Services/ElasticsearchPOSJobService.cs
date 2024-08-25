using CK.Central.Core.POS.Job.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.POS.Job.Services
{
    public class ElasticsearchPOSJobService : ElasticsearchBaseService, IElasticsearchPOSJobService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchPOSJobService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
