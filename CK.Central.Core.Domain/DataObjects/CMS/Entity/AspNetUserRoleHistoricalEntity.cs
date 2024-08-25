using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetUserRoleHistorical")]
    public partial class AspNetUserRoleHistoricalEntity : BaseEntity
    {
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [Column("action_datetime")]
        public DateTime? ActionDatetime { get; set; }

        [Column("action_by")]
        public string? ActionBy { get; set; }

        [Column("action_type")]
        public string? ActionType { get; set; }

        [Column("user_impact_id")]
        public string? UserImpactId { get; set; }

        [Column("user_impact_name")]
        public string? UserImpactName { get; set; }

        [Column("role_impact_id")]
        public string? RoleImpactId { get; set; }

        [Column("role_impact_name")]
        public string? RoleImpactName { get; set; }

        [Column("action_detail")]
        public string? ActionDetail { get; set; }

        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
