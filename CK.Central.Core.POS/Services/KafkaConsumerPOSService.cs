using CK.Central.Core.POS.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
    
namespace CK.Central.Core.POS.Services
{
    public class KafkaConsumerPOSService : KafkaConsumerBaseService, IKafkaConsumerPOSService
    {
        private readonly IConfiguration _configuration;
        public KafkaConsumerPOSService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
