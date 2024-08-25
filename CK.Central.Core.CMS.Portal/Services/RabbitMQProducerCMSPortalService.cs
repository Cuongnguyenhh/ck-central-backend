using CK.Central.Core.CMS.Portal.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Portal.Services
{
    public class RabbitMQProducerCMSPortalService : RabbitMQProducerBaseService, IRabbitMQProducerCMSPortalService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSPortalService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
