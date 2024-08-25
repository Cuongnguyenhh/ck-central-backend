using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using CK.Central.Core.GrabMart.Menu.Abstract.Services;
using CK.Central.Core.Domain.CMS.Constants;
using MediatR;
using Polly;
using Polly.Retry;
using static CK.Central.Core.Domain.DataObjects.GrabMart.Response.PartnerMartMenuResponseDto.SellingTime.ServiceHour;

namespace CK.Central.Core.GrabMart.Menu.Commands
{
    public class GetMartMenuCommand : PartnerMartMenuRequestDto, IRequest<PartnerMartMenuResponseDto>
    {
        public GetMartMenuCommand()
        { }
    }

    public class GetMartMenuCommandHandler : IRequestHandler<GetMartMenuCommand, PartnerMartMenuResponseDto>
    {
        private readonly IMenuMartRepository _repository;
        private readonly IRedisCacheGrabMartMenuService _redisCacheService;
        private AsyncRetryPolicy _retryPolicy;

        public GetMartMenuCommandHandler(IMenuMartRepository repository,
            IRedisCacheGrabMartMenuService redisCacheService)
        {
            _repository = repository;
            _redisCacheService = redisCacheService;
            _retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
        }

        public async Task<PartnerMartMenuResponseDto> Handle(GetMartMenuCommand request, CancellationToken cancellationToken)
        {
            var response = new PartnerMartMenuResponseDto();

            var cacheMenu = await _retryPolicy.ExecuteAsync<IEnumerable<MenuEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<MenuEntity>>(RedisCachingKey.LinkListActive));

            var cacheMenuItem = await _retryPolicy.ExecuteAsync<IEnumerable<MenuItemEntity>>(
                    async () => await _redisCacheService.GetData<IEnumerable<MenuItemEntity>>(RedisCachingKey.TokenListActive));

            if (cacheMenu != null && cacheMenuItem != null)
            {
                foreach (var menu in cacheMenu)
                {
                    response.merchantID = string.Empty;
                    response.partnerMerchantID = string.Empty;

                    response.currency = new PartnerMartMenuResponseDto.CurrencyObj
                    {
                        code = "VND",
                        symbol = "$",
                        exponent = 1
                    };

                    response.sellingTimes = new List<PartnerMartMenuResponseDto.SellingTime>
                    {
                        new PartnerMartMenuResponseDto.SellingTime
                        {
                            id = Guid.NewGuid().ToString(),
                            startTime = DateTime.Now.ToString(),
                            endTime = DateTime.Now.AddDays(365).ToString(),
                            name = "Best deal",
                            serviceHours = new PartnerMartMenuResponseDto.SellingTime.ServiceHour()
                            {
                                mon = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.monObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                tue = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.tueObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                wed = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.wedObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                thu = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.thuObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                fri = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.friObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                sat = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.satObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                },
                                sun = new PartnerMartMenuResponseDto.SellingTime.ServiceHour.sunObj
                                {
                                    openPeriodType = "OpenPeriod",
                                    periods = new List<period>
                                    {
                                        new period{startTime = "06:00", endTime = "22:00"}
                                    }
                                }
                            }
                        }
                    };

                    response.categories = new List<PartnerMartMenuResponseDto.Category>
                    {
                        new PartnerMartMenuResponseDto.Category
                        {
                            id = Guid.NewGuid().ToString(),
                            name = menu.Name,
                            availableStatus = "AVAILABLE",
                            sellingTimeID = response.sellingTimes.FirstOrDefault()?.id,
                            subCategories = new List<PartnerMartMenuResponseDto.Category.SubCategory>
                            {
                                new PartnerMartMenuResponseDto.Category.SubCategory
                                {
                                    id = Guid.NewGuid().ToString(),
                                    name = menu.Name,
                                    availableStatus = "AVAILABLE",
                                    sellingTimeID = response.sellingTimes.FirstOrDefault()?.id,
                                    items = new List<PartnerMartMenuResponseDto.Category.SubCategory.Item>
                                    {
                                        new PartnerMartMenuResponseDto.Category.SubCategory.Item
                                        {
                                            id = Guid.NewGuid().ToString(),
                                            name = menu.Name,
                                            nameTranslation = new PartnerMartMenuResponseDto.Category.SubCategory.Item.NameTranslation{en = string.Empty},
                                            price = 0,
                                            photos = new List<string> {"", "" },
                                            specialType = null,
                                            taxable = false,
                                            barcode = null,
                                            maxStock = 0,
                                            maxCount = 0,
                                            weight = new PartnerMartMenuResponseDto.Category.SubCategory.Item.Weight
                                            {
                                                unit = "", count = 0, value = 0
                                            },
                                            soldByWeight = true,
                                            sellingUom = new PartnerMartMenuResponseDto.Category.SubCategory.Item.SellingUom
                                            {
                                                len = 0,
                                                width = 0,
                                                height = 0,
                                                weight = 0
                                            },
                                            sellingTimeID = response.sellingTimes.FirstOrDefault()?.id,
                                            advancedPricing = new PartnerMartMenuResponseDto.Category.SubCategory.Item.AdvancedPricing
                                            {
                                                Delivery_OnDemand_GrabApp = 30,
                                                Delivery_Scheduled_GrabApp = 30,
                                                SelfPickUp_OnDemand_GrabApp = 25,
                                                SelfPickUp_OnDemand_StoreFront = 25,
                                                Delivery_OnDemand_StoreFront = 25,
                                                Delivery_Scheduled_StoreFront = 25
                                            },
                                            purchasability = new PartnerMartMenuResponseDto.Category.SubCategory.Item.Purchasability
                                            {
                                                Delivery_OnDemand_GrabApp = true,
                                                Delivery_Scheduled_GrabApp = true,
                                                Delivery_OnDemand_StoreFront = true,
                                                Delivery_Scheduled_StoreFront = true,
                                                SelfPickUp_OnDemand_StoreFront = true,
                                                SelfPickUp_OnDemand_GrabApp = true
                                            },
                                            modifierGroups = new List<PartnerMartMenuResponseDto.Category.SubCategory.Item.ModifierGroup>
                                            {
                                                new PartnerMartMenuResponseDto.Category.SubCategory.Item.ModifierGroup
                                                {
                                                    id = Guid.NewGuid().ToString(),
                                                    name = "",
                                                    nameTranslation = new PartnerMartMenuResponseDto.Category.SubCategory.Item.NameTranslation(),
                                                    availableStatus = "AVAILABLE",
                                                    selectionRangeMin = 0,
                                                    selectionRangeMax = 0,
                                                    modifiers = new List<PartnerMartMenuResponseDto.Category.SubCategory.Item.ModifierGroup.Modifier>()
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    };
                }
            }

            return response;
        }
    }
}
