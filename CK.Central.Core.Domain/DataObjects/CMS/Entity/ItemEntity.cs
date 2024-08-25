using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CK.Central.Core.Domain.DataObjects.CMS.Entity
{
    [Serializable]
    [Table("item")]
    public partial class ItemEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_country_uuid")]
        public Guid? CountryUUID { get; set; }

        [DataMember]
        [Column("country_code")]
        public string? CountryCode { get; set; }

        [DataMember]
        [Column("country_name")]
        public string? CountryName { get; set; }

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
        [Column("fk_product_status_uuid")]
        public Guid? ProductStatusUUID { get; set; }

        [DataMember]
        [Column("product_status_code")]
        public string? ProductStatusCode { get; set; }

        [DataMember]
        [Column("product_status_name")]
        public string? ProductStatusName { get; set; }

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
