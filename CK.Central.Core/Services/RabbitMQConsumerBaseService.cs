﻿using CK.Central.Core.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CK.Central.Core.Services
{
    public abstract class RabbitMQConsumerBaseService : IRabbitMQConsumerBaseService, IDisposable
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        public RabbitMQConsumerBaseService(IRabbitMQBaseService rabbitMqService)
        {
            _connection = rabbitMqService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false);
            _model.ExchangeDeclare("your.exchange.name", ExchangeType.Fanout, durable: true, autoDelete: false);
            _model.QueueBind(_queueName, "your.exchange.name", string.Empty);
        }
        const string _queueName = "your.queue.name";
        public async Task ReadMessgaes()
        {
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = System.Text.Encoding.UTF8.GetString(body);
                Console.WriteLine(text);
                await Task.CompletedTask;
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            if (_model.IsOpen)
                _model.Close();
            if (_connection.IsOpen)
                _connection.Close();
        }
    }
}
