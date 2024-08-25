using CK.Central.Core.POS.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.POS.GrabMart.Order.Services
{
    public class RedisCachePOSGrabMartOrderService : RedisCacheBaseService, IRedisCachePOSGrabMartOrderService
    {
        private readonly IConfiguration _configuration;
        public RedisCachePOSGrabMartOrderService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
