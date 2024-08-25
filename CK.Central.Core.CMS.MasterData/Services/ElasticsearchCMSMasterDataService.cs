using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.MasterData.Services
{
    public class ElasticsearchCMSMasterDataService : ElasticsearchBaseService, IElasticsearchCMSMasterDataService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchCMSMasterDataService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
