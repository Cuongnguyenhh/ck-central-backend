using CK.Central.Core.Abstract.Services;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CK.Central.Core.Services
{
    public abstract class KafkaProducerBaseService : KafkaBaseService, IKafkaProducerBaseService
    {
        public KafkaProducerBaseService(IConfiguration configuration) : base(configuration)
        {}

        public async Task ProduceEvent(string topicName, string messageBody)
        {
            try
            {
                var producer = GetProducer();
                await EnsureTopic(topicName);

                var message = new Message<Null, string>
                {
                    Value = messageBody
                };

                await producer.ProduceAsync(topicName, message);
            }
            catch { }
        }
    }
}
