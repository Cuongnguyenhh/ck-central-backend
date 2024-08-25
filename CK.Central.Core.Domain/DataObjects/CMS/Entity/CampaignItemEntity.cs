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
    [Table("campaign_item")]
    public partial class CampaignItemEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_campaign_uuid")]
        public Guid CampaignUUID { get; set; }

        [DataMember]
        [Column("fk_service_uuid")]
        public Guid? ServiceUUID { get; set; }

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

        [Column("content_payload_json", TypeName = "json")]
        public string? ContentPayloadJson { get; set; }

        [Column("content_request_json", TypeName = "json")]
        public string? ContentRequestJson { get; set; }

        [Column("content_response_json", TypeName = "json")]
        public string? ContentResponseJson { get; set; }
    }
}
