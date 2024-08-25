using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetRoleClaim")]
    public partial class AspNetRoleClaimEntity
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("RoleId")]
        public string? RoleId { get; set; }

        [Column("ClaimType")]
        public string? ClaimType { get; set; }

        [Column("ClaimValue")]
        public string? ClaimValue { get; set; }
    }
}
