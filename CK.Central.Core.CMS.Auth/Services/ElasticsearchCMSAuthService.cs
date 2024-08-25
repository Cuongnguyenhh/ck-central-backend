using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Auth.Services
{
    public class ElasticsearchCMSAuthService : ElasticsearchBaseService, IElasticsearchCMSAuthService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchCMSAuthService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
