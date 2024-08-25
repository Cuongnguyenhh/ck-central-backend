using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Model
{
    public class KafkaSettingsModel
    {
        public required string Uri { get; set; } = null!;
        public required string Host { get; set; } = null!;
        public required string Port { get; set; } = null!;
        public string? User { get; set; } = null!;
        public string? Pass { get; set; } = null!;
    }
}
