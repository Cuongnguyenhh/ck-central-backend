using CK.Central.Core.POS.GrabMart.Stock.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.POS.GrabMart.Stock.Services
{
    public class KafkaProducerPOSGrabMartStockService : KafkaProducerBaseService, IKafkaProducerPOSGrabMartStockService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerPOSGrabMartStockService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
