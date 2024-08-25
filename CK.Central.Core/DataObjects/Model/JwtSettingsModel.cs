using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Model
{
    public class JwtSettingsModel
    {
        public string? SymmetricSecurityKey { get; set; }
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public int? TokenValidityInMinutes { get; set; }
        public int? RefreshTokenValidityInDays { get; set; }
    }
}
