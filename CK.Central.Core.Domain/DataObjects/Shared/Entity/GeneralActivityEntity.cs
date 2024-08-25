using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.Shared.Entity
{
    [Serializable]
    [Table("general_activity")]
    public partial class GeneralActivityEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("service_request")]
        public string? ServiceRequest { get; set; }

        [DataMember]
        [Column("service_response")]
        public string? ServiceResponse { get; set; }

        [DataMember]
        [Column("kafka_topic_send")]
        public string? KafkaTopicSend { get; set; }

        [DataMember]
        [Column("kafka_topic_receive")]
        public string? KafkaTopicReceive { get; set; }

        [DataMember]
        [Column("rabbit_mq_queue")]
        public string? RabbitMQQueue { get; set; }

        [DataMember]
        [Column("rabbit_mq_exchange")]
        public string? RabbitMQExchange { get; set; }

        [DataMember]
        [Column("rabbit_mq_message")]
        public string? RabbitMQMessage { get; set; }

        [DataMember]
        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [DataMember]
        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [DataMember]
        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
