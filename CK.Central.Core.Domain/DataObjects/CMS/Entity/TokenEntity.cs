using CK.Central.Core.DataObjects.Entity;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("token")]
    public partial class TokenEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid? ServiceUUID { get; set; }

        [DataMember]
        [Column("client_id")]
        public string? ClientId { get; set; }

        [DataMember]
        [Column("client_secret")]
        public string? ClientSecret { get; set; }

        [DataMember]
        [Column("grant_type")]
        public string? GrantType { get; set; }

        [DataMember]
        [Column("scope")]
        public string? Scope { get; set; }

        [DataMember]
        [Column("uri")]
        public string? Uri { get; set; }

        [DataMember]
        [Column("certificate")]
        public string? Certificate { get; set; }

        [DataMember]
        [Column("public_key")]
        public string? PublicKey { get; set; }

        [DataMember]
        [Column("private_key")]
        public string? PrivateKey { get; set; }

        [DataMember]
        [Column("algorithm")]
        public string? Algorithm { get; set; }

        [DataMember]
        [Column("valid_issuer")]
        public string? ValidIssuer { get; set; }

        [DataMember]
        [Column("valid_audience")]
        public string? ValidAudience { get; set; }

        [DataMember]
        [Column("symmetric_security_key")]
        public string? SymmetricSecurityKey { get; set; }

        [DataMember]
        [Column("access_token_validity")]
        public int? AccessTokenValidity { get; set; }

        [DataMember]
        [Column("refresh_token_validity")]
        public int? RefreshTokenValidity { get; set; }

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
