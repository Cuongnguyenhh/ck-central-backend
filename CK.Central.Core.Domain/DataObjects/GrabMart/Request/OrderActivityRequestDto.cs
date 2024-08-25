using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class OrderActivityRequestDto : BaseRequestDto
    {
        public OrderActivityRequestDto() { }
        public OrderActivityRequestDto(OrderActivityEntity entity)
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

    public class EditOrderRequestDto
    {
        public string? orderID { get; set; }
        public List<Item>? items { get; set; }
        public bool? onlyRecalculate { get; set; }

        public class Item
        {
            public string? itemID { get; set; }
            public string? status { get; set; }
            public int? quantity { get; set; }
            public decimal? adjustedPriceInMin { get; set; }
            public decimal? adjustedWeight { get; set; }
        }
    }

    public class CancelOrderRequestDto
    {
        public string? orderID { get; set; }
        public string? merchantID { get; set; }
        public int? cancelCode { get; set; }
    }
}
