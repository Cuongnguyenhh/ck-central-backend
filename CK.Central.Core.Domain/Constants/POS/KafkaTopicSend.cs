using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.Constants
{
    public class KafkaTopicSend
    {
        public const string response_create_order_detail = "response-topic-create-order-detail";
        public const string response_update_order_detail = "response-topic-update-order-detail";
        public const string response_cancel_order_detail = "response-topic-cancel-order-detail";
        public const string response_check_stock_item = "response-topic-check-stock-iteml";
    }
}
