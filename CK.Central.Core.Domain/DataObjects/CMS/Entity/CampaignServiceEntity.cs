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
    [Table("campaign_service")]
    public partial class CampaignServiceEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_campaign_uuid")]
        public Guid CampaignUUID { get; set; }

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
        [Column("fk_country_uuid")]
        public Guid? CountryUUID { get; set; }

        [DataMember]
        [Column("fk_province_uuid")]
        public Guid? ProvinceUUID { get; set; }

        [DataMember]
        [Column("province_code")]
        public string? ProvinceCode { get; set; }

        [DataMember]
        [Column("province_name")]
        public string? ProvinceName { get; set; }

        [DataMember]
        [Column("fk_city_uuid")]
        public Guid? CityUUID { get; set; }

        [DataMember]
        [Column("city_code")]
        public string? CityCode { get; set; }

        [DataMember]
        [Column("city_name")]
        public string? CityName { get; set; }

        [DataMember]
        [Column("fk_area_uuid")]
        public Guid? AreaUUID { get; set; }

        [DataMember]
        [Column("area_code")]
        public string? AreaCode { get; set; }

        [DataMember]
        [Column("area_name")]
        public string? AreaName { get; set; }

        [DataMember]
        [Column("fk_store_uuid")]
        public Guid? StoreUUID { get; set; }

        [DataMember]
        [Column("store_code")]
        public string? StoreCode { get; set; }

        [DataMember]
        [Column("store_name")]
        public string? StoreName { get; set; }

        [DataMember]
        [Column("fk_department_uuid")]
        public Guid? DepartmentUUID { get; set; }

        [DataMember]
        [Column("department_code")]
        public string? DepartmentCode { get; set; }

        [DataMember]
        [Column("department_name")]
        public string? DepartmentName { get; set; }

        [DataMember]
        [Column("fk_category_uuid")]
        public Guid? CategoryUUID { get; set; }

        [DataMember]
        [Column("category_code")]
        public string? CategoryCode { get; set; }

        [DataMember]
        [Column("category_name")]
        public string? CategoryName { get; set; }

        [DataMember]
        [Column("fk_sub_category_uuid")]
        public Guid? SubCategoryUUID { get; set; }

        [DataMember]
        [Column("sub_category_code")]
        public string? SubCategoryCode { get; set; }

        [DataMember]
        [Column("sub_category_name")]
        public string? SubCategoryName { get; set; }

        [DataMember]
        [Column("fk_campaign_type_uuid")]
        public Guid? CampaignTypeUUID { get; set; }

        [DataMember]
        [Column("campaign_type")]
        public string? CampaignType { get; set; }

        [DataMember]
        [Column("campaign_status")]
        public string? CampaignStatus { get; set; }

        [DataMember]
        [Column("promotion_name")]
        public string? PromotionName { get; set; }

        [DataMember]
        [Column("promotion_level")]
        public string? PromotionLevel { get; set; }

        [DataMember]
        [Column("discount_type")]
        public string? DiscountType { get; set; }

        [DataMember]
        [Column("discount_object")]
        public string? DiscountObject { get; set; }

        [DataMember]
        [Column("discount_amount")]
        public decimal? DiscountAmount { get; set; }

        [DataMember]
        [Column("final_price")]
        public decimal? FinalPrice { get; set; }

        [DataMember]
        [Column("min_order_value")]
        public int? MinOrderValue { get; set; }

        [DataMember]
        [Column("bundle_quantity")]
        public int? BundleQuantity { get; set; }

        [DataMember]
        [Column("tag_custom_bundle")]
        public string? TagCustomBundle { get; set; }

        [DataMember]
        [Column("mex_funding_rate")]
        public decimal? MexFundingRate { get; set; }

        [DataMember]
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [DataMember]
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [DataMember]
        [Column("day_of_week")]
        public string? DayOfWeek { get; set; }

        [DataMember]
        [Column("time_effective")]
        public string? TimeEffective { get; set; }

        [DataMember]
        [Column("maximum_number_of_redemptions")]
        public int? MaximumNumberOfRedemptions { get; set; }

        [DataMember]
        [Column("maximum_redemptions_per_customer")]
        public int? MaximumRedemptionsPerCustomer { get; set; }

        [DataMember]
        [Column("maximum_number_of_redemptions_daily")]
        public int? MaximumNumberOfRedemptionsDaily { get; set; }

        [DataMember]
        [Column("maximum_redemptions_per_customer_daily")]
        public int? MaximumRedemptionsPerCustomerDaily { get; set; }

        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
