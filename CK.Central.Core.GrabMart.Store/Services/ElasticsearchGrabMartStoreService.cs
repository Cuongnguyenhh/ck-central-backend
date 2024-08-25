using CK.Central.Core.GrabMart.Store.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Store.Services
{
    public class ElasticsearchGrabMartStoreService : ElasticsearchBaseService, IElasticsearchGrabMartStoreService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchGrabMartStoreService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
