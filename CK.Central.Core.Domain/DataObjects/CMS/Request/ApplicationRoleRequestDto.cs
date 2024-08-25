using System.ComponentModel.DataAnnotations;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class ApplicationRoleRequestDto
    {
        public ApplicationRoleRequestDto() { }
    }

    public class SeedRolesRequestDto
    {
        public List<string>? Roles { get; set; }
    }

    public class UpdatePermissionRequestDto
    {
        [Required]
        public required string Username { get; set; }
    }
}
