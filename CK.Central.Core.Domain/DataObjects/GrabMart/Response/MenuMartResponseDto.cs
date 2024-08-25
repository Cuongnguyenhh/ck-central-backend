using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class MenuMartResponseDto : BaseResponseDto
    {
        public MenuMartResponseDto() { }
        public MenuMartResponseDto(MenuMartEntity entity)
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

    public class PartnerMartMenuResponseDto
    {
        public string? merchantID { get; set; }
        public string? partnerMerchantID { get; set; }
        public CurrencyObj? currency { get; set; }
        public List<SellingTime>? sellingTimes { get; set; }
        public List<Category>? categories { get; set; }

        public class CurrencyObj()
        {
            public string? code { get; set; }
            public string? symbol { get; set; }
            public int? exponent { get; set; }
        }

        public class SellingTime()
        {
            public string? startTime { get; set; }
            public string? endTime { get; set; }
            public string? id { get; set; }
            public string? name { get; set; }
            public ServiceHour? serviceHours { get; set; }

            public class ServiceHour()
            {
                public monObj? mon { get; set; }
                public tueObj? tue { get; set; }
                public wedObj? wed { get; set; }
                public thuObj? thu { get; set; }
                public friObj? fri { get; set; }
                public satObj? sat { get; set; }
                public sunObj? sun { get; set; }

                public class monObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class tueObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class wedObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class thuObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class friObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class satObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class sunObj()
                {
                    public string? openPeriodType { get; set; }
                    public List<period>? periods { get; set; }
                }

                public class period()
                {
                    public string? startTime { get; set; }
                    public string? endTime { get; set; }
                }
            }
        }

        public class Category()
        {
            public string? id { get; set; }
            public string? name { get; set; }
            public string? availableStatus { get; set; }
            public string? sellingTimeID { get; set; }
            public List<SubCategory> subCategories { get; set; }

            public class SubCategory()
            {
                public string? id { get; set; }
                public string? name { get; set; }
                public string? availableStatus { get; set; }
                public string? sellingTimeID { get; set; }
                public List<Item>? items { get; set; }

                public class Item()
                {
                    public string? id { get; set; }
                    public string? name { get; set; }
                    public NameTranslation? nameTranslation { get; set; }
                    public string? availableStatus { get; set; }
                    public string? description { get; set; }
                    public DescriptionTranslation? descriptionTranslation { get; set; }
                    public decimal? price { get; set; }
                    public List<string>? photos { get; set; }
                    public string? specialType { get; set; }
                    public bool? taxable { get; set; }
                    public string? barcode { get; set; }
                    public int? maxStock { get; set; }
                    public int? maxCount { get; set; }
                    public Weight? weight { get; set; }
                    public bool? soldByWeight { get; set; }
                    public SellingUom? sellingUom { get; set; }
                    public string? sellingTimeID { get; set; }
                    public AdvancedPricing? advancedPricing { get; set; }
                    public Purchasability? purchasability { get; set; }
                    public List<ModifierGroup> modifierGroups { get; set; }

                    public class NameTranslation()
                    {
                        public string? en { get; set; }
                    }

                    public class DescriptionTranslation()
                    {
                        public string? en { get; set; }
                    }

                    public class Weight()
                    {
                        public string? unit { get; set; }
                        public int? value { get; set; }
                        public int? count { get; set; }
                    }

                    public class SellingUom()
                    {
                        public decimal? len { get; set; }
                        public decimal? width { get; set; }
                        public decimal? height { get; set; }
                        public decimal? weight { get; set; }
                    }

                    public class AdvancedPricing()
                    {
                        public int? Delivery_OnDemand_GrabApp { get; set; }
                        public int? Delivery_Scheduled_GrabApp { get; set; }
                        public int? SelfPickUp_OnDemand_GrabApp { get; set; }
                        public int? Delivery_OnDemand_StoreFront { get; set; }
                        public int? Delivery_Scheduled_StoreFront { get; set; }
                        public int? SelfPickUp_OnDemand_StoreFront { get; set; }
                    }

                    public class Purchasability()
                    {
                        public bool? Delivery_OnDemand_GrabApp { get; set; }
                        public bool? Delivery_Scheduled_GrabApp { get; set; }
                        public bool? SelfPickUp_OnDemand_GrabApp { get; set; }
                        public bool? Delivery_OnDemand_StoreFront { get; set; }
                        public bool? Delivery_Scheduled_StoreFront { get; set; }
                        public bool? SelfPickUp_OnDemand_StoreFront { get; set; }
                    }

                    public class ModifierGroup()
                    {
                        public string? id { get; set; }
                        public string? name { get; set; }
                        public NameTranslation? nameTranslation { get; set; }
                        public string? availableStatus { get; set; }
                        public int? selectionRangeMin { get; set; }
                        public int? selectionRangeMax { get; set; }
                        public List<Modifier>? modifiers {  get; set; } 

                        public class Modifier()
                        {
                            public string? id { get; set; }
                            public string? name { get; set; }
                            public NameTranslation? nameTranslation { get; set; }
                            public string? availableStatus { get; set; }
                            public decimal? price { get; set; }
                            public string? barcode { get; set; }
                            public AdvancedPricing? advancedPricing { get; set; }
                        }
                    }
                }
            }
        }
    }
}
