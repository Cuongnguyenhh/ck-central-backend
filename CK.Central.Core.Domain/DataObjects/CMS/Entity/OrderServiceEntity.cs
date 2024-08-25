using CK.Central.Core.DataObjects.Entity;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("order_service")]
    public partial class OrderServiceEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_order_uuid")]
        public Guid OrderUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid ServiceUUID { get; set; }

        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("partner_order_id")]
        public string? PartnerOrderId { get; set; }

        [DataMember]
        [Column("short_order_number")]
        public string? ShortOrderNumber { get; set; }

        [DataMember]
        [Column("merchant_id")]
        public string? MerchantId { get; set; }

        [DataMember]
        [Column("partner_merchant_id")]
        public string? PartnerMerchantId { get; set; }

        [DataMember]
        [Column("payment_type")]
        public string? PaymentType { get; set; }

        [DataMember]
        [Column("order_time")]
        public string? OrderTime { get; set; }

        [DataMember]
        [Column("submit_time")]
        public string? SubmitTime { get; set; }

        [DataMember]
        [Column("complete_time")]
        public string? CompleteTime { get; set; }

        [DataMember]
        [Column("scheduled_time")]
        public string? ScheduledTime { get; set; }

        [DataMember]
        [Column("order_state")]
        public string? OrderState { get; set; }

        [DataMember]
        [Column("currency_code")]
        public string? CurrencyCode { get; set; }

        [DataMember]
        [Column("currency_symbol")]
        public string? CurrencySymbol { get; set; }

        [DataMember]
        [Column("currency_exponent")]
        public int? CurrencyExponent { get; set; }

        [DataMember]
        [Column("order_accepted_type")]
        public string? OrderAcceptedType { get; set; }

        [DataMember]
        [Column("order_type")]
        public string? OrderType { get; set; }

        [DataMember]
        [Column("is_mex_edit_order")]
        public bool? IsMexEditOrder { get; set; }

        [DataMember]
        [Column("price_subtotal")]
        public decimal? PriceSubtotal { get; set; }

        [DataMember]
        [Column("price_tax")]
        public decimal? PriceTax { get; set; }

        [DataMember]
        [Column("price_merchant_charge_fee")]
        public decimal? PriceMerchantChargeFee { get; set; }

        [DataMember]
        [Column("price_partner_fund_promo")]
        public decimal? PricePartnerFundPromo { get; set; }

        [DataMember]
        [Column("price_merchant_fund_promo")]
        public decimal? PriceMerchantFundPromo { get; set; }

        [DataMember]
        [Column("price_basket_promo")]
        public decimal? PriceBasketPromo { get; set; }

        [DataMember]
        [Column("price_delivery_fee")]
        public decimal? PriceDeliveryFee { get; set; }

        [DataMember]
        [Column("price_eater_payment")]
        public decimal? PriceEaterPayment { get; set; }

        [DataMember]
        [Column("receiver_name")]
        public string? ReceiverName { get; set; }

        [DataMember]
        [Column("receiver_phones")]
        public string? ReceiverPhones { get; set; }

        [DataMember]
        [Column("receiver_unit_number")]
        public string? ReceiverUnitNumber { get; set; }

        [DataMember]
        [Column("receiver_delivery_instruction")]
        public string? ReceiverDeliveryInstruction { get; set; }

        [DataMember]
        [Column("receiver_poi_source")]
        public string? ReceiverPoiSource { get; set; }

        [DataMember]
        [Column("receiver_poi_id")]
        public string? ReceiverPoiId { get; set; }

        [DataMember]
        [Column("receiver_address")]
        public string? ReceiverAddress { get; set; }

        [DataMember]
        [Column("receiver_postcode")]
        public string? ReceiverPostcode { get; set; }

        [DataMember]
        [Column("receiver_coordinates_latitude")]
        public string? ReceiverCoordinatesLatitude { get; set; }

        [DataMember]
        [Column("receiver_coordinates_longitude")]
        public string? ReceiverCoordinatesLongitude { get; set; }

        [DataMember]
        [Column("is_allow_change")]
        public bool? IsAllowChange { get; set; }

        [DataMember]
        [Column("estimated_order_ready_time")]
        public string? EstimatedOrderReadyTime { get; set; }

        [DataMember]
        [Column("max_order_ready_time")]
        public string? MaxOrderReadyTime { get; set; }

        [DataMember]
        [Column("new_order_ready_time")]
        public string? NewOrderReadyTime { get; set; }

        [DataMember]
        [Column("membership_id")]
        public string? MembershipId { get; set; }

        [DataMember]
        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [DataMember]
        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [DataMember]
        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
