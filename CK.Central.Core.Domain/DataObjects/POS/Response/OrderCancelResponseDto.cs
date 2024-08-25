using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.Domain.DataObjects.POS.Response
{
    public class OrderCancelResponseDto : BaseResponseDto
    {
        public OrderCancelResponseDto() { }
        public OrderCancelResponseDto(OrderCancelEntity entity)
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

    public class CancelOrderResponseDto
    {
        public CancelOrderResponseDto() { }

        public Guid OrderId { get; set; }
    }
}
