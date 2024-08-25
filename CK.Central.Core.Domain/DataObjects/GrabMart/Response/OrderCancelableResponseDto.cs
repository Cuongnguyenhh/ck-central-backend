using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class OrderCancelableResponseDto : BaseResponseDto
    {
        public OrderCancelableResponseDto() { }
        public OrderCancelableResponseDto(OrderCancelableEntity entity)
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

    public class CheckOrderCancelableResponseDto
    {
        public bool? cancelAble { get; set; }
        public string? nonCancellationReason { get; set; }
        public string? limitType { get; set; }
        public int? limitTimes { get; set; }
        public List<CancelReason>? cancelReasons { get; set; }

        public class CancelReason
        {
            public int? code { get; set; }
            public string? reason { get; set; }
        }
    }
}
