using CK.Central.Core.GrabMart.Order.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Order.Services
{
    public class RedisCacheGrabMartOrderService : RedisCacheBaseService, IRedisCacheGrabMartOrderService
    {
        private readonly IConfiguration _configuration;
        public RedisCacheGrabMartOrderService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
