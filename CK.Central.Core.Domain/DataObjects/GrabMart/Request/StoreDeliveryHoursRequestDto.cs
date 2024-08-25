using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class StoreDeliveryHoursRequestDto : BaseRequestDto
    {
        public StoreDeliveryHoursRequestDto() { }
        public StoreDeliveryHoursRequestDto(StoreDeliveryHoursEntity entity)
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

    public class UpdateDeliveryHoursRequestDto
    {
        public string? merchantID { get; set; }
        public OpeningHour? openingHour { get; set; }
        public bool? force { get; set; }

        public class OpeningHour
        {
            public List<DayTime>? mon {  get; set; }
            public List<DayTime>? tue { get; set; }
            public List<DayTime>? wed { get; set; }
            public List<DayTime>? thu { get; set; }
            public List<DayTime>? fri { get; set; }
            public List<DayTime>? sat { get; set; }
            public List<DayTime>? sun { get; set; }

            public class DayTime
            {
                public string? startTime { get; set; }
                public string? endTime { get; set; }
            }
        }
    }
}
