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
    [Table("AspNetUserLogin")]
    [Keyless]
    public partial class AspNetUserLoginEntity
    {
        [Column("LoginProvider")]
        public string? LoginProvider { get; set; }

        [Column("ProviderKey")]
        public string? ProviderKey { get; set; }

        [Column("ProviderDisplayName")]
        public string? ProviderDisplayName { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }
    }
}
