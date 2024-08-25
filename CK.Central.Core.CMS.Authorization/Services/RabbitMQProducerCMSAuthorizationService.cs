using CK.Central.Core.CMS.Authorization.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Authorization.Services
{
    public class RabbitMQProducerCMSAuthorizationService : RabbitMQProducerBaseService, IRabbitMQProducerCMSAuthorizationService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSAuthorizationService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
