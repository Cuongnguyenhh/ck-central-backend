using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class MenuSyncWebhookRequestDto : BaseRequestDto
    {
        public MenuSyncWebhookRequestDto() { }
        public MenuSyncWebhookRequestDto(MenuSyncWebhookEntity entity)
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

    public class PartnerMenuSyncWebhookRequestDto
    {
        public string? requestID { get; set; }
        public string? merchantID { get; set; }
        public string? partnerMerchantID { get; set; }
        public string? jobID { get; set; }
        public string? updatedAt { get; set; }
        public string? status { get; set; }

        public List<string>? errors { get; set; }
    }
}
