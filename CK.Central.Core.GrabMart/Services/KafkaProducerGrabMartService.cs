using CK.Central.Core.GrabMart.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Services
{
    public class KafkaProducerGrabMartService : KafkaProducerBaseService, IKafkaProducerGrabMartService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerGrabMartService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
