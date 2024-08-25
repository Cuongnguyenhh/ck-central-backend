using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Model
{
    public class SmtpSettingsModel
    {
        public string? Server { get; set; }
        public int? Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FromEmail { get; set; }
    }
}
