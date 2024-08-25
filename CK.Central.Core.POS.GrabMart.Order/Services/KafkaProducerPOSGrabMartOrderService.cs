using CK.Central.Core.POS.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.POS.GrabMart.Order.Services
{
    public class KafkaProducerPOSGrabMartOrderService : KafkaProducerBaseService, IKafkaProducerPOSGrabMartOrderService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerPOSGrabMartOrderService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
