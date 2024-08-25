using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class ResetPasswordRequestDto
    {
        public string? Password { get; set; }
        public string? UserId { get; set; }
        public string? Code { get; set; }
    }
}
