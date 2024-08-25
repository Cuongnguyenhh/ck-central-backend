using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Response
{
    public class ApplicationRoleResponseDto
    {
    }

    public class UpdatePermissionResponseDto
    {
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }
    }
}
