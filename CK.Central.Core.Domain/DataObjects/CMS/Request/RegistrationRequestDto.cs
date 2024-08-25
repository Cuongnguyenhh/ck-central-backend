using CK.Central.Core.Domain.DataObjects.CMS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class RegistrationRequestDto
    {
        public RegistrationRequestDto() { }

        [Required]
        public required string ActionBy { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Role { get; set; }

        public string? EmployeeCode { get; set; }
    }
}
