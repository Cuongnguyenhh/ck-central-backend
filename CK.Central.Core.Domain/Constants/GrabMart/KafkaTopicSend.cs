using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.GrabMart.Constants
{
    public class KafkaTopicSend
    {
        public const string cms_response_create_order_detail = "ck-central-cms-create-order-detail";
        public const string pos_response_create_order_detail = "ck-central-pos-create-order-detail";
        public const string pos_request_check_stock_detail = "ck-central-pos-create-order-detail";
    }
}
