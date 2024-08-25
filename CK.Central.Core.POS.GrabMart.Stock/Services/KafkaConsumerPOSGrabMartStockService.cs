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
    public class KafkaConsumerPOSGrabMartStockService : KafkaConsumerBaseService, IKafkaConsumerPOSGrabMartStockService
    {
        private readonly IConfiguration _configuration;
        public KafkaConsumerPOSGrabMartStockService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
