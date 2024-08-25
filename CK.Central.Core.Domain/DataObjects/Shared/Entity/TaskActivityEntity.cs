using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.Shared.Entity
{
    [Serializable]
    [Table("task_activity")]
    public partial class TaskActivityEntity : BaseEntity
    {
        [DataMember]
        [Column("fk_type_uuid")]
        public Guid TypeUUID { get; set; }

        [DataMember]
        [Column("fk_status_uuid")]
        public Guid StatusUUID { get; set; }

        [DataMember]
        [Column("fk_job_uuid")]
        public Guid JobUUID { get; set; }

        [DataMember]
        [Column("start_datetime")]
        public DateTime? StartDatetime { get; set; }

        [DataMember]
        [Column("end_datetime")]
        public DateTime? EndDatetime { get; set; }

        [DataMember]
        [Column("interval_in_second")]
        public int? IntervalInSecond { get; set; }

        [DataMember]
        [Column("interval_in_minute")]
        public int? IntervalInMinute { get; set; }

        [DataMember]
        [Column("interval_in_hour")]
        public int? IntervalInHour { get; set; }

        [DataMember]
        [Column("interval_in_day")]
        public int? IntervalInDay { get; set; }

        [DataMember]
        [Column("interval_in_week")]
        public int? IntervalInWeek { get; set; }

        [DataMember]
        [Column("interval_in_month")]
        public int? IntervalInMonth { get; set; }

        [DataMember]
        [Column("interval_in_quarter")]
        public int? IntervalInQuarter { get; set; }

        [DataMember]
        [Column("interval_in_year")]
        public int? IntervalInYear { get; set; }

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
