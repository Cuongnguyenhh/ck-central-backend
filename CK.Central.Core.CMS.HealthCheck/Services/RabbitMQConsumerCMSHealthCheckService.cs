using CK.Central.Core.CMS.HealthCheck.Abstract.Services;
using CK.Central.Core.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CK.Central.Core.Abstract.Services;

namespace CK.Central.Core.CMS.HealthCheck.Services
{
    public class RabbitMQConsumerCMSHealthCheckService : RabbitMQConsumerBaseService, IRabbitMQConsumerCMSHealthCheckService
    {
        private readonly IRabbitMQBaseService _rabbitMQBaseService;

        public RabbitMQConsumerCMSHealthCheckService(IRabbitMQBaseService rabbitMqService) : base(rabbitMqService)
        {
            _rabbitMQBaseService = rabbitMqService;
        }
    }
}
