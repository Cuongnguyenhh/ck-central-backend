using CK.Central.Core.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Order.Services
{
    public class KafkaConsumerGrabMartOrderService : KafkaConsumerBaseService, IKafkaConsumerGrabMartOrderService
    {
        private readonly IConfiguration _configuration;
        public KafkaConsumerGrabMartOrderService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
