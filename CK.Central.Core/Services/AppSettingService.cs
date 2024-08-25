using CK.Central.Core.Abstract.Services;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.Services
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IConfiguration _configuration;
        public AppSettingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string AppSettingValue(string RequestedData)
        {
            return (_configuration[RequestedData]);
        }
    }
}
