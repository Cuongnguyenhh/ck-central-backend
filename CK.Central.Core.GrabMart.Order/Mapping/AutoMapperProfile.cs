using AutoMapper;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;

namespace CK.Central.Core.GrabMart.Order.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<OrderActivityEntity, OrderActivityRequestDto>().ReverseMap();
            CreateMap<OrderActivityEntity, OrderActivityResponseDto>().ReverseMap();
            CreateMap<OrderActivityRequestDto, OrderActivityEntity>().ReverseMap();
            CreateMap<OrderActivityResponseDto, OrderActivityEntity>().ReverseMap();

            CreateMap<OrderCampaignEntity, OrderCampaignRequestDto>().ReverseMap();
            CreateMap<OrderCampaignEntity, OrderCampaignResponseDto>().ReverseMap();
            CreateMap<OrderCampaignRequestDto, OrderCampaignEntity>().ReverseMap();
            CreateMap<OrderCampaignResponseDto, OrderCampaignEntity>().ReverseMap();

            CreateMap<OrderCampaignItemEntity, OrderCampaignItemRequestDto>().ReverseMap();
            CreateMap<OrderCampaignItemEntity, OrderCampaignItemResponseDto>().ReverseMap();
            CreateMap<OrderCampaignItemRequestDto, OrderCampaignItemEntity>().ReverseMap();
            CreateMap<OrderCampaignItemResponseDto, OrderCampaignItemEntity>().ReverseMap();

            CreateMap<OrderCancelableEntity, OrderCancelableRequestDto>().ReverseMap();
            CreateMap<OrderCancelableEntity, OrderCancelableResponseDto>().ReverseMap();
            CreateMap<OrderCancelableRequestDto, OrderCancelableEntity>().ReverseMap();
            CreateMap<OrderCancelableResponseDto, OrderCancelableEntity>().ReverseMap();

            CreateMap<OrderHistoricalEntity, OrderHistoricalRequestDto>().ReverseMap();
            CreateMap<OrderHistoricalEntity, OrderHistoricalResponseDto>().ReverseMap();
            CreateMap<OrderHistoricalRequestDto, OrderHistoricalEntity>().ReverseMap();
            CreateMap<OrderHistoricalResponseDto, OrderHistoricalEntity>().ReverseMap();

            CreateMap<OrderItemEntity, OrderItemRequestDto>().ReverseMap();
            CreateMap<OrderItemEntity, OrderItemResponseDto>().ReverseMap();
            CreateMap<OrderItemRequestDto, OrderItemEntity>().ReverseMap();
            CreateMap<OrderItemResponseDto, OrderItemEntity>().ReverseMap();

            CreateMap<OrderItemModifierEntity, OrderItemModifierRequestDto>().ReverseMap();
            CreateMap<OrderItemModifierEntity, OrderItemModifierResponseDto>().ReverseMap();
            CreateMap<OrderItemModifierRequestDto, OrderItemModifierEntity>().ReverseMap();
            CreateMap<OrderItemModifierResponseDto, OrderItemModifierEntity>().ReverseMap();

            CreateMap<OrderListEntity, OrderListRequestDto>().ReverseMap();
            CreateMap<OrderListEntity, OrderListResponseDto>().ReverseMap();
            CreateMap<OrderListRequestDto, OrderListEntity>().ReverseMap();
            CreateMap<OrderListResponseDto, OrderListEntity>().ReverseMap();

            CreateMap<OrderPriceEntity, OrderPriceRequestDto>().ReverseMap();
            CreateMap<OrderPriceEntity, OrderPriceResponseDto>().ReverseMap();
            CreateMap<OrderPriceRequestDto, OrderPriceEntity>().ReverseMap();
            CreateMap<OrderPriceResponseDto, OrderPriceEntity>().ReverseMap();

            CreateMap<OrderPromotionEntity, OrderPromotionRequestDto>().ReverseMap();
            CreateMap<OrderPromotionEntity, OrderPromotionResponseDto>().ReverseMap();
            CreateMap<OrderPromotionRequestDto, OrderPromotionEntity>().ReverseMap();
            CreateMap<OrderPromotionResponseDto, OrderPromotionEntity>().ReverseMap();

            CreateMap<OrderReadyEntity, OrderReadyRequestDto>().ReverseMap();
            CreateMap<OrderReadyEntity, OrderReadyResponseDto>().ReverseMap();
            CreateMap<OrderReadyRequestDto, OrderReadyEntity>().ReverseMap();
            CreateMap<OrderReadyResponseDto, OrderReadyEntity>().ReverseMap();

            CreateMap<OrderReadyEstimationEntity, OrderReadyEstimationRequestDto>().ReverseMap();
            CreateMap<OrderReadyEstimationEntity, OrderReadyEstimationResponseDto>().ReverseMap();
            CreateMap<OrderReadyEstimationRequestDto, OrderReadyEstimationEntity>().ReverseMap();
            CreateMap<OrderReadyEstimationResponseDto, OrderReadyEstimationEntity>().ReverseMap();

            CreateMap<OrderReceiverEntity, OrderReceiverRequestDto>().ReverseMap();
            CreateMap<OrderReceiverEntity, OrderReceiverResponseDto>().ReverseMap();
            CreateMap<OrderReceiverRequestDto, OrderReceiverEntity>().ReverseMap();
            CreateMap<OrderReceiverResponseDto, OrderReceiverEntity>().ReverseMap();

            CreateMap<OrderServiceEntity, OrderServiceRequestDto>().ReverseMap();
            CreateMap<OrderServiceEntity, OrderServiceResponseDto>().ReverseMap();
            CreateMap<OrderServiceRequestDto, OrderServiceEntity>().ReverseMap();
            CreateMap<OrderServiceResponseDto, OrderServiceEntity>().ReverseMap();

            CreateMap<OrderStateEntity, OrderStateRequestDto>().ReverseMap();
            CreateMap<OrderStateEntity, OrderStateResponseDto>().ReverseMap();
            CreateMap<OrderStateRequestDto, OrderStateEntity>().ReverseMap();
            CreateMap<OrderStateResponseDto, OrderStateEntity>().ReverseMap();

            CreateMap<OrderSubmitEntity, OrderSubmitRequestDto>().ReverseMap();
            CreateMap<OrderSubmitEntity, OrderSubmitResponseDto>().ReverseMap();
            CreateMap<OrderSubmitRequestDto, OrderSubmitEntity>().ReverseMap();
            CreateMap<OrderSubmitResponseDto, OrderSubmitEntity>().ReverseMap();
        }
    }
}
