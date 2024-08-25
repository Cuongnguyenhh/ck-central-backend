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
    [Table("menu_template")]
    public partial class MenuTemplateEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid ServiceUUID { get; set; }

        [DataMember]
        [Column("fk_menu_uuid")]
        public Guid? MenuUUID { get; set; }

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
        [Column("fk_file_uuid")]
        public Guid? FileUUID { get; set; }

        [DataMember]
        [Column("menu_template")]
        public string? MenuTemplate { get; set; }

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
