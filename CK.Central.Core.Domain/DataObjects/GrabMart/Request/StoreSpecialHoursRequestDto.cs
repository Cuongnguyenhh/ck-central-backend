using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class StoreSpecialHoursRequestDto : BaseRequestDto
    {
        public StoreSpecialHoursRequestDto() { }
        public StoreSpecialHoursRequestDto(StoreSpecialHoursEntity entity)
        {
            PK_UUID = entity.PK_UUID;
            Parent_UUID = entity.Parent_UUID;
            Name = entity.Name;
            Code = entity.Code;
            Description = entity.Description;
            IsActive = entity.IsActive;
            IsDeleted = entity.IsDeleted;
            CreatedBy = entity.CreatedBy;
            CreatedDatetime = entity.CreatedDatetime;
            UpdatedBy = entity.UpdatedBy;
            UpdatedDatetime = entity.UpdatedDatetime;
            DeletedBy = entity.DeletedBy;
            DeletedDatetime = entity.DeletedDatetime;
        }
    }

    public class UpdateSpecialHoursRequestDto
    {
        public string? merchantID { get; set; }
        public List<SpecialOpeningHour>? specialOpeningHours { get; set; }

        public class SpecialOpeningHour
        {
            public string? startDate { get; set; }
            public string? endDate { get; set; }
            public Metadata? metadata { get; set; }
            public OpeningHour? openingHours { get; set; }

            public class Metadata
            {
                public string? description { get; set; }
            }

            public class OpeningHour
            {
                public string? openPeriodType { get; set; }
                public List<Period>? periods { get; set; }

                public class Period
                {
                    public string? startTime { get; set; }
                    public string? endTime { get; set; }
                }
            }
        }
    }
}
