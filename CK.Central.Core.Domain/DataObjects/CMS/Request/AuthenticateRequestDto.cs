using IdentityModel.Client;
using IdentityModel.OidcClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class AuthenticateRequestDto
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }

    public class TokenRequestExtension : TokenRequest
    {
        public required string Username { get; set; }

        public required string Password { get; set; }

        public required List<string> Roles { get; set; }
    }
}
