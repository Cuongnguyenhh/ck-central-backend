using CK.Central.Core.Abstract.Services;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.Services
{
    public class RabbitMQProducerBaseService : IRabbitMQProducerBaseService
    {
        private readonly ConnectionFactory _factory;
        private readonly IConfiguration _configuration;

        public RabbitMQProducerBaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _factory = new ConnectionFactory
            {
                HostName = _configuration.GetSection("RabbitMQServer:Host").Value,
            };
        }
        public async Task PublishMessgaes(string queue, string exchange, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    channel.BasicPublish(
                        exchange: exchange,
                        routingKey: queue,
                        basicProperties: properties,
                        body: message);
                }
            }

            await Task.CompletedTask;
        }
    }
}
