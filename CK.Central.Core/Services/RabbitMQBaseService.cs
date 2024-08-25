using CK.Central.Core.Abstract.Services;
using Microsoft.AspNetCore.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace CK.Central.Core.Services
{
    public class RabbitMQBaseService : IRabbitMQBaseService
    {
        private readonly RabbitMqConfiguration _rabbitMqConfiguration;
        private readonly IConfiguration _configuration;
        public RabbitMQBaseService(IOptions<RabbitMqConfiguration> options, IConfiguration configuration)
        {
            _rabbitMqConfiguration = options.Value;
            _configuration = configuration;
        }
        public IConnection CreateChannel()
        {
            ConnectionFactory connection = new ConnectionFactory()
            {
                UserName = _rabbitMqConfiguration.Username,
                Password = _rabbitMqConfiguration.Password,
                HostName = _rabbitMqConfiguration.HostName
            };
            connection.DispatchConsumersAsync = true;
            var channel = connection.CreateConnection();
            return channel;
        }
    }

    public class RabbitMqConfiguration
    {
        public string? HostName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
