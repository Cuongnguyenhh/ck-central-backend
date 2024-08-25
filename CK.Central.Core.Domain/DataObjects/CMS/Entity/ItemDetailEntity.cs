using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using YamlDotNet.Core;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("item_detail")]
    public partial class ItemDetailEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_item_uuid")]
        public Guid? ItemUUID { get; set; }

        [DataMember]
        [Column("non_accented_vn")]
        public string? NonAccentedVN { get; set; }

        [DataMember]
        [Column("accented_vn")]
        public string? AccentedVN { get; set; }

        [DataMember]
        [Column("name_en")]
        public string? NameEN { get; set; }

        [DataMember]
        [Column("short_name_en")]
        public string? ShortNameEN { get; set; }

        [DataMember]
        [Column("short_name_vn")]
        public string? ShortNameVN { get; set; }

        [DataMember]
        [Column("fk_brand_uuid")]
        public Guid? BrandUUID { get; set; }

        [DataMember]
        [Column("brand_code")]
        public string? BrandCode { get; set; }

        [DataMember]
        [Column("brand_name")]
        public string? BrandName { get; set; }

        [DataMember]
        [Column("fk_sales_unit_uuid")]
        public Guid? SalesUnitUUID { get; set; }

        [DataMember]
        [Column("sales_unit_code")]
        public string? SalesUnitCode { get; set; }

        [DataMember]
        [Column("sales_unit_name")]
        public string? SalesUnitName { get; set; }

        [DataMember]
        [Column("fk_purchasing_unit_uuid")]
        public Guid? PurchasingUnitUUID { get; set; }

        [DataMember]
        [Column("purchasing_unit_code")]
        public string? PurchasingUnitCode { get; set; }

        [DataMember]
        [Column("purchasing_unit_name")]
        public string? PurchasingUnitName { get; set; }

        [DataMember]
        [Column("fk_inventory_unit_uuid")]
        public Guid? InventoryUnitUUID { get; set; }

        [DataMember]
        [Column("inventory_unit_code")]
        public string? InventoryUnitCode { get; set; }

        [DataMember]
        [Column("inventory_unit_name")]
        public string? InventoryUnitName { get; set; }

        [DataMember]
        [Column("vat_in")]
        public decimal? VATIn { get; set; }

        [DataMember]
        [Column("vat_in_text")]
        public string? VATInText { get; set; }

        [DataMember]
        [Column("vat_out")]
        public decimal? VATOut { get; set; }

        [DataMember]
        [Column("vat_out_text")]
        public string? VATOutText { get; set; }

        [DataMember]
        [Column("shelf_life")]
        public int? ShelfLife { get; set; }

        [DataMember]
        [Column("min_order_qty")]
        public int? MinOrderQty { get; set; }

        [DataMember]
        [Column("max_order_qty")]
        public int? MaxOrderQty { get; set; }

        [DataMember]
        [Column("price_unit_vat")]
        public decimal? PriceUnitVAT { get; set; }

        [DataMember]
        [Column("main_vendor_id")]
        public string? MainVendorId { get; set; }

        [DataMember]
        [Column("fk_material_type_uuid")]
        public Guid? MaterialTypeUUID { get; set; }

        [DataMember]
        [Column("material_type_code")]
        public string? MaterialTypeCode { get; set; }

        [DataMember]
        [Column("material_type_name")]
        public string? MaterialTypeName { get; set; }

        [DataMember]
        [Column("remaining_shelf_life")]
        public int? RemainingShelfLife { get; set; }

        [DataMember]
        [Column("sale_tax_type_cd")]
        public string? SaleTaxTypeCd { get; set; }

        [DataMember]
        [Column("order_tax_type_cd")]
        public string? OrderTaxTypeCd { get; set; }

        [DataMember]
        [Column("base_order_price")]
        public decimal? BaseOrderPrice { get; set; }

        [DataMember]
        [Column("min_order_qty_dc")]
        public int? MinOrderQtyDc { get; set; }

        [DataMember]
        [Column("max_order_qty_dc")]
        public int? MaxOrderQtyDc { get; set; }

        [DataMember]
        [Column("order_pause_flg")]
        public string? OrderPauseFlg { get; set; }

        [DataMember]
        [Column("return_pause_flg")]
        public string? ReturnPauseFlg { get; set; }

        [DataMember]
        [Column("standard_smallest_barcode")]
        public string? StandardSmallestBarcode { get; set; }

        [DataMember]
        [Column("standard_purchase_barcode")]
        public string? StandardPurchaseBarcode { get; set; }

        [DataMember]
        [Column("ou_code")]
        public string? OuCode { get; set; }

        [DataMember]
        [Column("is_active_text")]
        public string? IsActiveText { get; set; }

        [DataMember]
        [Column("name_en_price_label")]
        public string? NameENPriceLabel { get; set; }

        [DataMember]
        [Column("name_vn_price_label")]
        public string? NameVNPriceLabel { get; set; }

        [DataMember]
        [Column("origin")]
        public string? Origin { get; set; }

        [DataMember]
        [Column("storage_condition")]
        public string? StorageCondition { get; set; }

        [DataMember]
        [Column("remark")]
        public string? Remark { get; set; }

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
