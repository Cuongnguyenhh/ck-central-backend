using CK.Central.Core.GrabMart.HealthCheck.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.HealthCheck.Services
{
    public class ElasticsearchGrabMartHealthCheckService : ElasticsearchBaseService, IElasticsearchGrabMartHealthCheckService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchGrabMartHealthCheckService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
