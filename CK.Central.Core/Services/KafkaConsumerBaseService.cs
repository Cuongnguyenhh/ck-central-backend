using CK.Central.Core.Abstract.Services;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.Services
{
    public abstract class KafkaConsumerBaseService : KafkaBaseService, IKafkaConsumerBaseService
    {
        public KafkaConsumerBaseService(IConfiguration configuration) : base(configuration)
        { }

        public async Task<IConsumer<Ignore, string>>? CreateConsumer(string topicName)
        {
            try
            {
                var consumer = new ConsumerBuilder<Ignore, string>(GetConsumerConfig).Build();
                await EnsureTopic(topicName);

                return consumer;
            }
            catch
            {
                return null!;
            }
        }
    }
}
