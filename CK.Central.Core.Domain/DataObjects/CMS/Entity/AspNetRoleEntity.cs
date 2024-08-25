using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetRole")]
    public class AspNetRoleEntity
    {
        [Column("Id")]
        public required string Id { get; set; }

        [Column("RoleType")]
        public int? RoleType { get; set; }

        [Column("RoleTypeName")]
        public string? RoleTypeName { get; set; }

        [Column("IsAdmin")]
        public bool? IsAdmin { get; set; }

        [Column("Group")]
        public int? Group { get; set; }

        [Column("GroupName")]
        public string? GroupName { get; set; }

        [Column("Status")]
        public int? Status { get; set; }

        [Column("StatusName")]
        public string? StatusName { get; set; }

        [Column("Type")]
        public int? Type { get; set; }

        [Column("TypeName")]
        public string? TypeName { get; set; }

        [Column("Code")]
        public string? Code { get; set; }

        [Column("ParentId")]
        public string? ParentId { get; set; }

        [Column("Description")]
        public string? Description { get; set; }

        [Column("IsActive")]
        public System.Boolean? IsActive { get; set; }

        [Column("IsDeleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("CreatedBy")]
        public string? CreatedBy { get; set; }

        [Column("CreatedDatetime")]
        public DateTime? CreatedDatetime { get; set; }

        [Column("UpdatedBy")]
        public string? UpdatedBy { get; set; }

        [Column("UpdatedDatetime")]
        public DateTime? UpdatedDatetime { get; set; }

        [Column("DeletedBy")]
        public string? DeletedBy { get; set; }

        [Column("DeletedDatetime")]
        public DateTime? DeletedDatetime { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("NormalizedName")]
        public string? NormalizedName { get; set; }

        [NotMapped]
        [Column("ConcurrencyStamp")]
        public string? ConcurrencyStamp { get; set; }
    }
}
