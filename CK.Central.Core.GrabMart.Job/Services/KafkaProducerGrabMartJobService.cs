using CK.Central.Core.GrabMart.Job.Abstract.Services;
using CK.Central.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.GrabMart.Job.Services
{
    public class KafkaProducerGrabMartJobService : KafkaProducerBaseService, IKafkaProducerGrabMartJobService
    {
        private readonly IConfiguration _configuration;
        public KafkaProducerGrabMartJobService(IConfiguration configuration) : base(configuration) => this._configuration = configuration;
    }
}
