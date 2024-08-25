using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("customer")]
    public partial class CustomerEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("id_card")]
        public string? IdCard { get; set; }

        [DataMember]
        [Column("mobile_phones")]
        public string? MobilePhones { get; set; }

        [DataMember]
        [Column("nationality")]
        public string? Nationality { get; set; }

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
        [Column("district")]
        public string? District { get; set; }

        [DataMember]
        [Column("ward")]
        public string? Ward { get; set; }

        [DataMember]
        [Column("address_number")]
        public string? AddressNumber { get; set; }

        [DataMember]
        [Column("post_code")]
        public string? PostCode { get; set; }

        [DataMember]
        [Column("coordinates_latitude")]
        public string? CoordinatesLatitude { get; set; }

        [DataMember]
        [Column("coordinates_longitude")]
        public string? CoordinatesLongitude { get; set; }

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
