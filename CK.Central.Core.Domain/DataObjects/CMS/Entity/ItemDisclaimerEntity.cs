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
    [Table("item_disclaimer")]
    public partial class ItemDisclaimerEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_item_uuid")]
        public Guid? ItemUUID { get; set; }

        [DataMember]
        [Column("item_code")]
        public string? ItemCode { get; set; }

        [DataMember]
        [Column("item_name")]
        public string? ItemName { get; set; }

        [DataMember]
        [Column("fk_disclaimer_uuid")]
        public Guid? DisclaimerUUID { get; set; }

        [DataMember]
        [Column("disclaimer_code")]
        public string? DisclaimerCode { get; set; }

        [DataMember]
        [Column("disclaimer_name")]
        public string? DisclaimerName { get; set; }

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
