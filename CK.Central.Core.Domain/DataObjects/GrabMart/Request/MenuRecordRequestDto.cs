using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Request
{
    public class MenuRecordRequestDto : BaseRequestDto
    {
        public MenuRecordRequestDto() { }
        public MenuRecordRequestDto(MenuRecordEntity entity)
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

    public class UpdateMenuItemRequestDto()
    {
        public string? merchantID { get; set; }
        public string? field { get; set; }
        public string? id { get; set; }
        public decimal? price { get; set; }
        public string? availableStatus { get; set; }
        public int? maxStock { get; set; }
        public List<AdvancedPricing>? advancedPricings { get; set; }
        public List<Purchasability>? purchasabilities { get; set; }

        public class AdvancedPricing()
        {
            public string? key { get; set; }
            public decimal? price { get; set; }
        }

        public class Purchasability()
        {
            public string? key { get; set; }
            public bool? purchasable { get; set; }
        }
    }

    public class UpdateModifierRequestDto()
    {
        public string? merchantID { get; set; }
        public string? field { get; set; }
        public string? id { get; set; }
        public decimal? price { get; set; }
        public string? availableStatus { get; set; }
        public string? name { get; set; }
        public bool? isFree { get; set; }
        public List<AdvancedPricing>? advancedPricings { get; set; }

        public class AdvancedPricing()
        {
            public string? key { get; set; }
            public decimal? price { get; set; }
        }
    }
}
