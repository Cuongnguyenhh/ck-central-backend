using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Auth.Services
{
    public class RabbitMQProducerCMSAuthService : RabbitMQProducerBaseService, IRabbitMQProducerCMSAuthService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSAuthService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
