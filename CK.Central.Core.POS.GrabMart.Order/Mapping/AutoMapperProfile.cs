using AutoMapper;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Domain.DataObjects.POS.Request;
using CK.Central.Core.Domain.DataObjects.POS.Response;

namespace CK.Central.Core.POS.GrabMart.Order.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<OrderActivityEntity, OrderActivityRequestDto>().ReverseMap();
            CreateMap<OrderActivityEntity, OrderActivityResponseDto>().ReverseMap();
            CreateMap<OrderActivityRequestDto, OrderActivityEntity>().ReverseMap();
            CreateMap<OrderActivityResponseDto, OrderActivityEntity>().ReverseMap();

            CreateMap<OrderCustomerEntity, OrderCustomerRequestDto>().ReverseMap();
            CreateMap<OrderCustomerEntity, OrderCustomerResponseDto>().ReverseMap();
            CreateMap<OrderCustomerRequestDto, OrderCustomerEntity>().ReverseMap();
            CreateMap<OrderCustomerResponseDto, OrderCustomerEntity>().ReverseMap();

            CreateMap<OrderHistoricalEntity, OrderHistoricalRequestDto>().ReverseMap();
            CreateMap<OrderHistoricalEntity, OrderHistoricalResponseDto>().ReverseMap();
            CreateMap<OrderHistoricalRequestDto, OrderHistoricalEntity>().ReverseMap();
            CreateMap<OrderHistoricalResponseDto, OrderHistoricalEntity>().ReverseMap();

            CreateMap<OrderInvoiceEntity, OrderInvoiceRequestDto>().ReverseMap();
            CreateMap<OrderInvoiceEntity, OrderInvoiceResponseDto>().ReverseMap();
            CreateMap<OrderInvoiceRequestDto, OrderInvoiceEntity>().ReverseMap();
            CreateMap<OrderInvoiceResponseDto, OrderInvoiceEntity>().ReverseMap();

            CreateMap<OrderItemEntity, OrderItemRequestDto>().ReverseMap();
            CreateMap<OrderItemEntity, OrderItemResponseDto>().ReverseMap();
            CreateMap<OrderItemRequestDto, OrderItemEntity>().ReverseMap();
            CreateMap<OrderItemResponseDto, OrderItemEntity>().ReverseMap();

            CreateMap<OrderServiceEntity, OrderServiceRequestDto>().ReverseMap();
            CreateMap<OrderServiceEntity, OrderServiceResponseDto>().ReverseMap();
            CreateMap<OrderServiceRequestDto, OrderServiceEntity>().ReverseMap();
            CreateMap<OrderServiceResponseDto, OrderServiceEntity>().ReverseMap();

            CreateMap<OrderSubmitEntity, OrderSubmitRequestDto>().ReverseMap();
            CreateMap<OrderSubmitEntity, OrderSubmitResponseDto>().ReverseMap();
            CreateMap<OrderSubmitRequestDto, OrderSubmitEntity>().ReverseMap();
            CreateMap<OrderSubmitResponseDto, OrderSubmitEntity>().ReverseMap();

            CreateMap<OrderUpdateEntity, OrderUpdateRequestDto>().ReverseMap();
            CreateMap<OrderUpdateEntity, OrderUpdateResponseDto>().ReverseMap();
            CreateMap<OrderUpdateRequestDto, OrderUpdateEntity>().ReverseMap();
            CreateMap<OrderUpdateResponseDto, OrderUpdateEntity>().ReverseMap();
        }
    }
}
