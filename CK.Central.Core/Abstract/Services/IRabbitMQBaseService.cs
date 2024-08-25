using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace CK.Central.Core.Abstract.Services
{
    public interface IRabbitMQBaseService
    {
        IConnection CreateChannel();
    }
}
