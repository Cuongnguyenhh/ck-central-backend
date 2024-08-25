using CK.Central.Core.POS.HealthCheck.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.POS.HealthCheck.Services
{
    public class KafkaProducerPOSHealthCheckService : KafkaProducerBaseService, IKafkaProducerPOSHealthCheckService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerPOSHealthCheckService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
