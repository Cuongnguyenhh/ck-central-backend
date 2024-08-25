using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class TokenRefreshRequestDto
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
