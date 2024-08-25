using Azure.Core;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Response
{
    public class AuthenticateResponseDto
    {
        public required string UserId { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? AccessTokenExpiryTime { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public required List<string> Roles { get; set; }
        public string? Message { get; set; }
    }
}
