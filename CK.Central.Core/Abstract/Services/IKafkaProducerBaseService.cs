using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IKafkaProducerBaseService
    {
        Task ProduceEvent(string topicName, string messageBody);
    }
}
