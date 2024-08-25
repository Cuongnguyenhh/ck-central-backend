using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Dto
{
    public class RefreshTokenRequestDto
    {
        public RefreshTokenRequestDto() { }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public TokenRequest? Token { get; set; }
    }
}
