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
    [Table("store_service")]
    public partial class StoreServiceEntity : BaseEntity
    {
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
        [Column("fk_store_uuid")]
        public Guid? StoreUUID { get; set; }

        [DataMember]
        [Column("store_code")]
        public string? StoreCode { get; set; }

        [DataMember]
        [Column("store_name")]
        public string? StoreName { get; set; }

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
        [Column("fk_province_uuid")]
        public Guid? ProvinceUUID { get; set; }

        [DataMember]
        [Column("province_code")]
        public string? ProvinceCode { get; set; }

        [DataMember]
        [Column("province_name")]
        public string? ProvinceName { get; set; }

        [DataMember]
        [Column("district")]
        public string? District { get; set; }

        [DataMember]
        [Column("ward")]
        public string? Ward { get; set; }

        [DataMember]
        [Column("street")]
        public string? Street { get; set; }

        [DataMember]
        [Column("address")]
        public string? Address { get; set; }

        [DataMember]
        [Column("phone_no")]
        public string? PhoneNo { get; set; }

        [DataMember]
        [Column("open_date")]
        public DateTime? OpenDate { get; set; }

        [DataMember]
        [Column("close_date")]
        public DateTime? CloseDate { get; set; }

        [DataMember]
        [Column("available_start_date")]
        public DateTime? AvailableStartDate { get; set; }

        [DataMember]
        [Column("available_end_date")]
        public DateTime? AvailableEndDate { get; set; }
        
        [DataMember]
        [Column("merchant_id")]
        public string? MerchantId { get; set; }

        [DataMember]
        [Column("partner_merchant_id")]
        public string? PartnerMerchantId { get; set; }

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
