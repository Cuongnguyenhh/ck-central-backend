using CK.Central.Core.DataObjects.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetUserLoginHistorical")]
    public partial class AspNetUserLoginHistoricalEntity : BaseEntity
    {
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [Column("login_datetime")]
        public DateTime? LoginDatetime { get; set; }

        [Column("logout_datetime")]
        public DateTime? LogoutDatetime { get; set; }

        [Column("user_name")]
        public string? UserName { get; set; }

        [Column("full_name")]
        public string? FullName { get; set; }

        [Column("machine_name")]
        public string? MachineName { get; set; }

        [Column("ip_address")]
        public string? IpAddress { get; set; }

        [Column("access_token")]
        public string? AccessToken { get; set; }

        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
