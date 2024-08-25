using CK.Central.Core.GrabMart.Menu.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Menu.Services
{
    public class ElasticsearchGrabMartMenuService : ElasticsearchBaseService, IElasticsearchGrabMartMenuService
    {
        private readonly IConfiguration _configuration;
        public ElasticsearchGrabMartMenuService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
