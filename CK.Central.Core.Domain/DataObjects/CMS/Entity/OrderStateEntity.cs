using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("order_state")]
    public partial class OrderStateEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid ServiceUUID { get; set; }

        [DataMember]
        [Column("fk_order_uuid")]
        public Guid? OrderUUID { get; set; }

        [DataMember]
        [Column("fk_order_state_uuid")]
        public Guid? OrderStateUUID { get; set; }

        [DataMember]
        [Column("order_state_code")]
        public string? OrderStateCode { get; set; }

        [DataMember]
        [Column("order_state_name")]
        public string? OrderStateName { get; set; }

        [DataMember]
        [Column("order_message")]
        public string? OrderMessage { get; set; }

        [DataMember]
        [Column("driver_eta")]
        public int? DriverETA { get; set; }

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
