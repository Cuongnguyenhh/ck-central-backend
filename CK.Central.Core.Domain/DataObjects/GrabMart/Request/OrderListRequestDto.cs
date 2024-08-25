using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System.Collections.Generic;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class OrderListRequestDto : BaseRequestDto
    {
        public OrderListRequestDto() { }
        public OrderListRequestDto(OrderListEntity entity)
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

    public class ListOrdersRequestDto()
    {
        public string? merchantID {  get; set; }
        public string? date { get; set; }
        public int? page { get; set; }
    }
}
