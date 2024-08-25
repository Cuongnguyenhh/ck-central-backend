using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class StoreHoursResponseDto : BaseResponseDto
    {
        public StoreHoursResponseDto() { }
        public StoreHoursResponseDto(StoreHoursEntity entity)
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

    public class GetStoreHoursResponseDto
    {
        public GetStoreHoursSuccessResponseDto? GetStoreHoursSuccess {  get; set; }
        public GetStoreStatusFailureResponseDto? GetStoreStatusFailure { get; set; }
    }

    public class GetStoreHoursSuccessResponseDto
    {
        public object? dineInHour { get; set; }
        public OpeningHour? openingHour { get; set; }
        public List<SpecialOpeningHour>? specialOpeningHours { get; set; }

        public class OpeningHour
        {
            public DayTime? mon {  get; set; }
            public DayTime? tue { get; set; }
            public DayTime? wed { get; set; }
            public DayTime? thu { get; set; }
            public DayTime? fri { get; set; }
            public DayTime? sat { get; set; }
            public DayTime? sun { get; set; }

            public class DayTime
            {
                public string? startTime { get; set; }
                public string? endTime { get; set; }
            }


        }

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

    public class GetStoreHoursFailureResponseDto
    {
        public string? reason {  get; set; }
        public string? message { get; set; }
    }
}
