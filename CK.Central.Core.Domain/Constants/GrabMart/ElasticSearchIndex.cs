using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.GrabMart.Constants
{
    public static class ElasticSearchIndex
    {
        public static string StoreDeliveryHours => "audit-log-store-delivery-hours";
        public static string StoreHistorical => "audit-log-store-historical";
        public static string StoreHours => "audit-log-store-hours";
        public static string StorePause => "audit-log-store-pause";
        public static string StoreService => "audit-log-store-delivery-hours";
        public static string StoreSpecialHours => "audit-log-store-special-hours";
        public static string StoreStatus => "audit-log-store-status";
    }
}
