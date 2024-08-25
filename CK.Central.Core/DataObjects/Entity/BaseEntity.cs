using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CK.Central.Core.DataObjects.Entity
{
    [Serializable]
    [DataContract(IsReference = true)]
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        [Column("pk_uuid")]
        [Required]
        public Guid PK_UUID { get; set; }

        [DataMember]
        [Column("name")]
        public string? Name { get; set; }

        [DataMember]
        [Column("description")]
        public string? Description { get; set; }

        [DataMember]
        [Column("is_active")]
        [Required]
        public required Boolean IsActive { get; set; }

        [DataMember]
        [Column("is_deleted")]
        [Required]
        public required Boolean IsDeleted { get; set; }

        [DataMember]
        [Column("code")]
        public string? Code { get; set; }

        [DataMember]
        [Column("parent_uuid")]
        public Guid? Parent_UUID { get; set; }

        [DataMember]
        [Column("created_by")]
        [Required]
        public required string CreatedBy { get; set; }

        [DataMember]
        [Column("created_datetime")]
        [Required]
        public required DateTime CreatedDatetime { get; set; }

        [DataMember]
        [Column("updated_by")]
        public string? UpdatedBy { get; set; }

        [DataMember]
        [Column("updated_datetime")]
        public DateTime? UpdatedDatetime { get; set; }

        [DataMember]
        [Column("deleted_by")]
        public string? DeletedBy { get; set; }

        [DataMember]
        [Column("deleted_datetime")]
        public DateTime? DeletedDatetime { get; set; }
    }
}
