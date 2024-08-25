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
    [Table("status")]
    public partial class StatusEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_group_uuid")]
        public Guid GroupUUID { get; set; }

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
