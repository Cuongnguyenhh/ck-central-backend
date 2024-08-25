using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class CampaignActivityResponseDto : BaseResponseDto
    {
        public CampaignActivityResponseDto() { }
        public CampaignActivityResponseDto(CampaignActivityEntity entity)
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

    public class CreateCampaignsSuccessResponseDto
    {
        public string? id {  get; set; }
    }

    public class CreateCampaignsFailureResponseDto
    {
        public string? target { get; set; }
        public string? reason { get; set; }
        public string? message { get; set; }
    }

    public class CreateCampaignsResponseDto()
    {
        public CreateCampaignsSuccessResponseDto? CreateCampaignsSuccess {  get; set; }
        public CreateCampaignsFailureResponseDto? CreateCampaignsFailure { get; set; }
    }

    public class DeleteCampaignResponseDto
    {
        public string? message { get; set;}
    }

    public class UpdateCampaignResponseDto
    {
        public string? message { get; set; }
    }
}
