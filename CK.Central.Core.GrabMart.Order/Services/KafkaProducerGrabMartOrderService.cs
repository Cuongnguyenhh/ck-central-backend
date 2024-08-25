using CK.Central.Core.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Order.Services
{
    public class KafkaProducerGrabMartOrderService : KafkaProducerBaseService, IKafkaProducerGrabMartOrderService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerGrabMartOrderService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
