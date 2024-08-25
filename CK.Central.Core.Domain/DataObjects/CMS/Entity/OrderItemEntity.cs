using CK.Central.Core.DataObjects.Entity;
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
    [Table("order_item")]
    public partial class OrderItemEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_order_uuid")]
        public Guid OrderUUID { get; set; }

        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid? ServiceUUID { get; set; }

        [DataMember]
        [Column("fk_item_uuid")]
        public Guid? ItemUUID { get; set; }

        [DataMember]
        [Column("item_code")]
        public string? ItemCode { get; set; }

        [DataMember]
        [Column("item_name_en")]
        public string? ItemNameEN { get; set; }

        [DataMember]
        [Column("item_name_vn")]
        public string? ItemNameVN { get; set; }

        [DataMember]
        [Column("item_non_accented_vn")]
        public string? ItemNonAccentedVN { get; set; }

        [DataMember]
        [Column("item_accented_vn")]
        public string? ItemAccentedVN { get; set; }

        [DataMember]
        [Column("item_short_name_en")]
        public string? ItemShortNameEN { get; set; }

        [DataMember]
        [Column("item_short_name_vn")]
        public string? ItemShortNameVN { get; set; }

        [DataMember]
        [Column("item_id")]
        public string? ItemId { get; set; }

        [DataMember]
        [Column("partner_item_id")]
        public string? PartnerItemId { get; set; }

        [DataMember]
        [Column("quantity")]
        public int? Quantity { get; set; }

        [DataMember]
        [Column("weight")]
        public decimal? Weight { get; set; }

        [DataMember]
        [Column("price")]
        public decimal? Price { get; set; }

        [DataMember]
        [Column("tax")]
        public decimal? Tax { get; set; }

        [DataMember]
        [Column("specifications")]
        public string? Specifications { get; set; }

        [DataMember]
        [Column("is_adjusted")]
        public bool? IsAdjusted { get; set; }

        [DataMember]
        [Column("adjusted_quantity")]
        public int? AdjustedQuantity { get; set; }

        [DataMember]
        [Column("adjusted_price_in_min")]
        public decimal? AdjustedPriceInMin { get; set; }

        [DataMember]
        [Column("adjusted_weight")]
        public decimal? AdjustedWeight { get; set; }

        [DataMember]
        [Column("adjusted_tax")]
        public decimal? AdjustedTax { get; set; }

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
