using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class StoreStatusResponseDto : BaseResponseDto
    {
        public StoreStatusResponseDto() { }
        public StoreStatusResponseDto(StoreStatusEntity entity)
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

    public class GetStoreStatusResponseDto
    {
        public GetStoreStatusSuccessResponseDto? GetStoreStatusSuccess {  get; set; }
        public GetStoreStatusFailureResponseDto? GetStoreStatusFailure { get; set; }
    }

    public class GetStoreStatusSuccessResponseDto
    {
        public string? closeReason {  get; set; }
        public bool? isInSpecialOpeningHourRange { get; set; }
        public bool? isOpen { get; set; }
    }

    public class GetStoreStatusFailureResponseDto
    {
        public string? reason { get; set; }
        public string? message { get; set; }
    }
}
