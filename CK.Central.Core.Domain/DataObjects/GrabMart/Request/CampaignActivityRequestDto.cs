using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class CampaignActivityRequestDto : BaseRequestDto
    {
        public CampaignActivityRequestDto() { }
        public CampaignActivityRequestDto(CampaignActivityEntity entity)
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

    public class CreateCampaignsRequestDto
    {
        public string? merchantID { get; set; }
        public string? name { get; set; }
        public Quotas? quotas { get; set; }
        public Conditions? conditions { get; set; }
        public Discount? discount { get; set; }
        public string? customTag { get; set; }

        public class Quotas
        {
            public int? totalCount { get; set; }
            public int? totalCountPerUser { get; set; }
        }

        public class Conditions
        {
            public string? startTime { get; set; }
            public string? endTime { get; set; }
            public string? eaterType { get; set; }
            public decimal? minBasketAmount { get; set; }
            public int? bundleQuantity { get; set; }
            public WorkingHour? workingHour { get; set; }

            public class WorkingHour
            {
                public DayTime? sun { get; set; }
                public DayTime? mon { get; set; }
                public DayTime? tue { get; set; }
                public DayTime? wed { get; set; }
                public DayTime? thu { get; set; }
                public DayTime? fri { get; set; }
                public DayTime? sat { get; set; }

                public class DayTime
                {
                    public List<Periods>? periods { get; set; }

                    public class Periods
                    {
                        public string? startTime { get; set; }
                        public string? endTime { get; set; }
                    }
                }
            }
        }

        public class Discount
        {
            public string? type { get; set; }
            public int? cap {  get; set; }
            public int? value { get; set; }
            public Scope? scope { get; set; }

            public class Scope
            {
                public string? type { get; set; }
                public List<string>? objectIDs { get; set; }
            }
        }
    }

    public class UpdateCampaignsRequestDto
    {
        public string? merchantID { get; set; }
        public string? name { get; set; }
        public Quotas? quotas { get; set; }
        public Conditions? conditions { get; set; }
        public Discount? discount { get; set; }
        public string? customTag { get; set; }

        public class Quotas
        {
            public int? totalCount { get; set; }
            public int? totalCountPerUser { get; set; }
        }

        public class Conditions
        {
            public string? startTime { get; set; }
            public string? endTime { get; set; }
            public string? eaterType { get; set; }
            public decimal? minBasketAmount { get; set; }
            public int? bundleQuantity { get; set; }
            public WorkingHour? workingHour { get; set; }

            public class WorkingHour
            {
                public DayTime? sun { get; set; }
                public DayTime? mon { get; set; }
                public DayTime? tue { get; set; }
                public DayTime? wed { get; set; }
                public DayTime? thu { get; set; }
                public DayTime? fri { get; set; }
                public DayTime? sat { get; set; }

                public class DayTime
                {
                    public List<Periods>? periods { get; set; }

                    public class Periods
                    {
                        public string? startTime { get; set; }
                        public string? endTime { get; set; }
                    }
                }
            }
        }

        public class Discount
        {
            public string? type { get; set; }
            public int? cap { get; set; }
            public int? value { get; set; }
            public Scope? scope { get; set; }

            public class Scope
            {
                public string? type { get; set; }
                public List<string>? objectIDs { get; set; }
            }
        }
    }

    public class DeleteCampaignRequestDto
    {
        public string? campaignId { get; set; }
    }
}
