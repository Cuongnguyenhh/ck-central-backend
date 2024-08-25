using CK.Central.Core.CMS.Generate.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Generate.Services
{
    public class RabbitMQProducerCMSGenerateService : RabbitMQProducerBaseService, IRabbitMQProducerCMSGenerateService
    {
        private readonly IConfiguration _configuration;

        public RabbitMQProducerCMSGenerateService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
