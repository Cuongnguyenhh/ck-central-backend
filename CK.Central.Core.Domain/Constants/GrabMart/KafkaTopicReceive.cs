using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.GrabMart.Constants
{
    public static class KafkaTopicReceive
    {
        public const string pos_request_check_stock_detail = "request-topic-create-order-detail";
        public const string request_update_order_detail = "request-topic-update-order-detail";
        public const string request_cancel_order_detail = "request-topic-cancel-order-detail";
        public const string request_check_stock_item = "request-topic-check-stock-iteml";
    }
}
