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
    [Table("menu_item")]
    public partial class MenuItemEntity : BaseEntity
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
        [Column("fk_menu_uuid")]
        public Guid? MenuUUID { get; set; }

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
        [Column("selling_price")]
        public decimal? SellingPrice { get; set; }

        [DataMember]
        [Column("available_start_date")]
        public DateTime? AvailableStartDate { get; set; }

        [DataMember]
        [Column("available_end_date")]
        public DateTime? AvailableEndDate { get; set; }

        [DataMember]
        [Column("special_price")]
        public decimal? SpecialPrice { get; set; }

        [DataMember]
        [Column("start_date")]
        public DateTime? StartDate { get; set; }

        [DataMember]
        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [DataMember]
        [Column("status_code")]
        public string? StatusCode { get; set; }

        [DataMember]
        [Column("status_name")]
        public string? StatusName { get; set; }

        [DataMember]
        [Column("display_priority")]
        public int? DisplayPriority { get; set; }

        [DataMember]
        [Column("image_link")]
        public string? ImageLink { get; set; }

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
