using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Dto
{
    public abstract class BaseRequestDto
    {
        public Guid? PK_UUID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public Boolean? IsActive { get; set; }

        public Boolean? IsDeleted { get; set; }

        public string? Code { get; set; }

        public Guid? Parent_UUID { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDatetime { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDatetime { get; set; }

        public string? DeletedBy { get; set; }

        public DateTime? DeletedDatetime { get; set; }
    }
}
