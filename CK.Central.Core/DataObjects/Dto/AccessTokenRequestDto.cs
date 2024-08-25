using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Dto
{
    public class AccessTokenRequestDto : TokenRequest
    {
        public AccessTokenRequestDto() { }

        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required List<string> Roles {  get; set; }
    }
}
