using CK.Central.Core.CMS.Authentication.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Authentication.Services
{
    public class RabbitMQProducerCMSAuthenticationService : RabbitMQProducerBaseService, IRabbitMQProducerCMSAuthenticationService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSAuthenticationService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
