using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IKafkaConsumerBaseService
    {
        Task<IConsumer<Ignore, string>>? CreateConsumer(string topicName);
    }
}
