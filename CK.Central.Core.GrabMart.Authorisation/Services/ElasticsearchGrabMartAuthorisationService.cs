using CK.Central.Core.GrabMart.Authorisation.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Authorisation.Services
{
    public class ElasticsearchGrabMartAuthorisationService : ElasticsearchBaseService, IElasticsearchGrabMartAuthorisationService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchGrabMartAuthorisationService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
