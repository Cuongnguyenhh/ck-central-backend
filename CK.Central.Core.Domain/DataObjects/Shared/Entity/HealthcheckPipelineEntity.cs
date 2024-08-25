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
    [Table("healthcheck_pipeline")]
    public partial class HealthcheckPipelineEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

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
