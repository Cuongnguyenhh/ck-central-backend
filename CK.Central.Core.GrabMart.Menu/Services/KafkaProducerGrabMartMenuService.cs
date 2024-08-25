using CK.Central.Core.GrabMart.Menu.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Menu.Services
{
    public class KafkaProducerGrabMartMenuService : KafkaProducerBaseService, IKafkaProducerGrabMartMenuService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerGrabMartMenuService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
