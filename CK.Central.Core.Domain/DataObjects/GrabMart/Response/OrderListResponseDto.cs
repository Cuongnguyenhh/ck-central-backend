using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class OrderListResponseDto : BaseResponseDto
    {
        public OrderListResponseDto() { }
        public OrderListResponseDto(OrderListEntity entity)
        {
            PK_UUID = entity.PK_UUID;
            Parent_UUID = entity.Parent_UUID;
            Name = entity.Name;
            Code = entity.Code;
            Description = entity.Description;
            IsActive = entity.IsActive;
            IsDeleted = entity.IsDeleted;
            CreatedBy = entity.CreatedBy;
            CreatedDatetime = entity.CreatedDatetime;
            UpdatedBy = entity.UpdatedBy;
            UpdatedDatetime = entity.UpdatedDatetime;
            DeletedBy = entity.DeletedBy;
            DeletedDatetime = entity.DeletedDatetime;
        }
    }

    public class ListOrdersResponseDto()
    {
        public bool? more { get; set; }

        public class Order()
        {
            public string? orderID { get; set; }
            public string? shortOrderNumber { get; set; }
            public string? merchantID { get; set; }
            public string? partnerMerchantID { get; set; }
            public string? paymentType { get; set; }
            public string? orderTime { get; set; }
            public string? submitTime { get; set; }
            public string? completeTime { get; set; }
            public string? scheduledTime { get; set; }
            public string? orderState { get; set; }
            public CurrencyObj? currency { get; set; }
            public FeatureFlag? featureFlags { get; set; }
            public List<Item>? items { get; set; }
            public List<Campaign>? campaigns { get; set; }
            public List<Promo>? promos { get; set; }
            public Price? price { get; set; }
            public Receiver? receiver { get; set; }
            public OrderReadyEstimation? orderReadyEstimation { get; set; }
            public string? membershipID { get; set; }

            public class CurrencyObj()
            {
                public string? code { get; set; }
                public string? symbol { get; set; }
                public int? exponent { get; set; }
            }

            public class FeatureFlag()
            {
                public string? orderAcceptedType { get; set; }
                public string? orderType { get; set; }
                public bool? isMexEditOrder { get; set; }
            }

            public class Item()
            {
                public string? id { get; set; }
                public string? grabItemID { get; set; }
                public int? quantity { get; set; }
                public decimal? price { get; set; }
                public decimal? tax { get; set; }
                public string? specifications { get; set; }
                public List<Modifier>? modifiers { get; set; }

                public class Modifier()
                {
                    public string id { get; set; }
                    public decimal? price { get; set; }
                    public decimal? tax { get; set; }
                    public int? quantity { get; set; }
                }
            }

            public class Campaign()
            {
                public string? id { get; set; }
                public string? name { get; set; }
                public string? campaignNameForMex { get; set; }
                public string? level { get; set; }
                public string? type { get; set; }
                public string? usageCount { get; set; }
                public string? mexFundedRatio { get; set; }
                public string? deductedAmount { get; set; }
                public string? deductedPart { get; set; }
                public List<string>? appliedItemIDs { get; set; }
                public FreeItem? freeItem { get; set; }

                public class FreeItem()
                {
                    public string? id { get; set; }
                    public string? name { get; set; }
                    public int? quantity { get; set; }
                    public decimal? price { get; set; }
                }
            }

            public class Promo()
            {
                public string? code { get; set; }
                public string? description { get; set; }
                public string? name { get; set; }
                public decimal? promoAmount { get; set; }
                public decimal? mexFundedRatio { get; set; }
                public decimal? mexFundedAmount { get; set; }
                public decimal? targetedPrice { get; set; }
                public decimal? promoAmountInMin { get; set; }
            }

            public class Price()
            {
                public decimal? subtotal { get; set; }
                public decimal? tax { get; set; }
                public decimal? merchantChargeFee { get; set; }
                public decimal? grabFundPromo { get; set; }
                public decimal? merchantFundPromo { get; set; }
                public decimal? basketPromo { get; set; }
                public decimal? deliveryFee { get; set; }
                public decimal? eaterPayment { get; set; }
            }

            public class Receiver()
            {
                public string? name { set; get; }
                public string? phones { get; set; }
                public Address? address { get; set; }

                public class Address()
                {
                    public string? unitNumber { set; get; }
                    public string? deliveryInstruction { set; get; }
                    public string? poiSource { set; get; }
                    public string? poiID { set; get; }
                    public string? address { set; get; }
                    public string? postcode { set; get; }
                    public Coordinate? coordinates { set; get; }

                    public class Coordinate()
                    {
                        public string? latitude { set; get; }
                        public string? longitude { set; get; }
                    }
                }
            }

            public class OrderReadyEstimation()
            {
              public bool? allowChange { get; set; }
              public string? estimatedOrderReadyTime { set; get; }
              public string? maxOrderReadyTime { set; get; }
              public string? newOrderReadyTime { set; get; }
            }
        }
    }
}
