using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetUserClaim")]
    public partial class AspNetUserClaimEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [Column("ClaimType")]
        public string? ClaimType { get; set; }

        [Column("ClaimValue")]
        public string? ClaimValue { get; set; }
    }
}
