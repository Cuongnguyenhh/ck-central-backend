using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IRabbitMQProducerBaseService
    {
        Task PublishMessgaes(string queue, string exchange, byte[] message);
    }
}
