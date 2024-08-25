using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IAppSettingService
    {
        public string AppSettingValue(string RequestedData);
    }
}
