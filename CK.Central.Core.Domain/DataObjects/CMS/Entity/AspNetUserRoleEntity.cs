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
    [Table("AspNetUserRole")]
    [Keyless]
    public partial class AspNetUserRoleEntity
    {
        [Column("UserId")]
        public string? UserId { get; set; }

        [Column("RoleId")]
        public string? RoleId { get; set; }
    }
}