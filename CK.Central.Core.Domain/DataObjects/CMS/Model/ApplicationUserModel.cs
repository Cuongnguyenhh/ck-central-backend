using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Model
{
    public class ApplicationUserModel : IdentityUser
    {
        public required string FisrtName {  get; set; }

        public required string LastName { get; set; }

        public string? FullName { get; set; }

        public string? EmployeeCode { get; set; }

        public int? Title { get; set; }

        public string? TitleName { get; set; }

        public int? Department { get; set; }

        public string? DepartmentName { get; set; }

        public bool? IsAdmin { get; set; } = false;

        public int? Group { get; set; }

        public string? GroupName { get; set; }

        public int? Status { get; set; }

        public string? StatusName { get; set; }

        public int? Type { get; set; }

        public string? TypeName { get; set; }

        public string? Code { get; set; }

        public string? ParentId { get; set; }

        public string? Description { get; set; }

        public Boolean? IsActive { get; set; }

        public Boolean? IsDeleted { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDatetime { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDatetime { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedDatetime { get; set; }
    }
}
