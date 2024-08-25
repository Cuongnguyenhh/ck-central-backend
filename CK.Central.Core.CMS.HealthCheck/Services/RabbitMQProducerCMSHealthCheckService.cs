using CK.Central.Core.CMS.HealthCheck.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.HealthCheck.Services
{
    public class RabbitMQProducerCMSHealthCheckService : RabbitMQProducerBaseService, IRabbitMQProducerCMSHealthCheckService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSHealthCheckService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
