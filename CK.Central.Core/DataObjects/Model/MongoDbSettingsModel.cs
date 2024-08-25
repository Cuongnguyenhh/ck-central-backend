using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Model
{
    public class MongoDbSettingsModel
    {
        public required string ConnectionString { get; set; } = null!;
        public required string DatabaseHost { get; set; } = null!;
        public required string DatabasePort { get; set; } = null!;
        public required string DatabaseName { get; set; } = null!;
        public string? Username { get; set; } = null!;
        public string? Password { get; set; } = null!;
    }
}
