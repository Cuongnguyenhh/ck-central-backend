using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("AspNetUser")]
    public partial class AspNetUserEntity
    {
        [Column("Id")]
        public required string Id { get; set; } = null!;

        [Column("FisrtName")]
        public string? FisrtName { get; set; }

        [Column("LastName")]
        public string? LastName { get; set; }

        [Column("FullName")]
        public string? FullName { get; set; }

        [Column("EmployeeCode")]
        public string? EmployeeCode { get; set; }

        [Column("Title")]
        public int? Title { get; set; }

        [Column("TitleName")]
        public string? TitleName { get; set; }

        [Column("Department")]
        public int? Department { get; set; }

        [Column("DepartmentName")]
        public string? DepartmentName { get; set; }

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

        [Column("UserName")]
        public string? UserName { get; set; }

        [Column("NormalizedUserName")]
        public string? NormalizedUserName { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("NormalizedEmail")]
        public string? NormalizedEmail { get; set; }

        [Column("EmailConfirmed")]
        public string? EmailConfirmed { get; set; }

        [Column("PasswordHash")]
        public string? PasswordHash { get; set; }

        [Column("SecurityStamp")]
        public string? SecurityStamp { get; set; }

        [Column("ConcurrencyStamp")]
        public string? ConcurrencyStamp { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("PhoneNumberConfirmed")]
        public bool PhoneNumberConfirmed { get; set; }

        [Column("TwoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [Column("LockoutEnd")]
        public DateTimeOffset? LockoutEnd { get; set; }

        [Column("LockoutEnabled")]
        public bool LockoutEnabled { get; set; }

        [Column("AccessFailedCount")]
        public int AccessFailedCount { get; set; }
    }
}
