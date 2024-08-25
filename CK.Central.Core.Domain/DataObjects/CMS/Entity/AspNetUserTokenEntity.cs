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
    [Table("AspNetUserToken")]
    [Keyless]
    public partial class AspNetUserTokenEntity
    {
        [Column("UserId")]
        public string? UserId { get; set; }
        
        [Column("LoginProvider")]
        public string? LoginProvider { get; set; }
        
        [Column("Name")]
        public string? Name { get; set; }
        
        [Column("Value")]
        public string? Value { get; set; }
    }
}