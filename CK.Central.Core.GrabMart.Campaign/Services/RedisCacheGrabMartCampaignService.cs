using CK.Central.Core.GrabMart.Campaign.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Campaign.Services
{
    public class RedisCacheGrabMartCampaignService : RedisCacheBaseService, IRedisCacheGrabMartCampaignService
    {
        private readonly IConfiguration _configuration;
        public RedisCacheGrabMartCampaignService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
