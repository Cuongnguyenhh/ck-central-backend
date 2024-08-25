using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Model
{
    public class ConnectionStringSettingsModel
    {
        public required string MasterPgsqlDbConnection { get; set; }
        public required string SlavePgsqlDbConnection { get; set; }
    }
}
