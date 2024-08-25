using CK.Central.Core.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace CK.Central.Core.Services
{
    public abstract class KafkaBaseService : IKafkaBaseService
    {
        private readonly IConfiguration _configuration;

        private readonly string? _connStr;
        private readonly string? _groupId;
        private readonly string? _retentionInMs;
        private readonly string? _numPartitions;

        public KafkaBaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            _connStr = _configuration["Kafka:Url"];
            _groupId = _configuration["Kafka:GroupId"];
            _retentionInMs = _configuration["Kafka:RetentionInMs"];
            _numPartitions = _configuration["Kafka:NumPartitions"];
        }

        private ProducerConfig GetProducerConfig => new()
        {
            BootstrapServers = _connStr,
            Acks = Acks.Leader,
        };

        private protected ConsumerConfig GetConsumerConfig => new()
        {
            BootstrapServers = _connStr,
            GroupId = _groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            AutoCommitIntervalMs = 1000
        };

        private AdminClientConfig GetAdminClientConfig => new()
        {
            BootstrapServers = _connStr
        };

        private protected IProducer<Null, string> GetProducer()
        {
            var producer = new ProducerBuilder<Null, string>(GetProducerConfig).Build();

            return producer;
        }

        private protected async Task EnsureTopic(string topicName)
        {
            try
            {
                var adminClient = new AdminClientBuilder(GetAdminClientConfig).Build();
                var topics = adminClient.GetMetadata(TimeSpan.FromSeconds(1)).Topics;

                var topicExist = topics.Any(x => x.Topic.Equals(topicName));

                if (!topicExist)
                {
                    var retentionInMilliseconds = Convert.ToInt32(_retentionInMs);

                    var topicSpec = new TopicSpecification
                    {
                        Name = topicName,
                        NumPartitions = Convert.ToInt32(_numPartitions),
                        ReplicationFactor = 1,
                        Configs = new() {{ "retention.ms", retentionInMilliseconds.ToString() }}
                    };

                    await adminClient.CreateTopicsAsync(new[] { topicSpec });
                }
            }
            catch (CreateTopicsException ex) { }
        }
    }
}