using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class OrderStateRequestDto : BaseRequestDto
    {
        public OrderStateRequestDto() { }
        public OrderStateRequestDto(OrderStateEntity entity)
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

    public class GrabPushOrderStateRequestDto()
    {
        public string? merchantID { get; set; }
        public string? orderID { get; set; }
        public string? state { get; set; }
        public string? driverETA { get; set; }
        public string? code { get; set; }
        public string? message { get; set; }
    }

    public class UpdateDeliveryStateRequestDto()
    {
        public string? orderID { get; set; }
        public string? fromState { get; set; }
        public string? toState { get; set; }
    }
}
