using AutoMapper;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;

namespace CK.Central.Core.CMS.Portal.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CampaignEntity, CampaignRequestDto>().ReverseMap();
            CreateMap<CampaignEntity, CampaignResponseDto>().ReverseMap();
            CreateMap<CampaignRequestDto, CampaignEntity>().ReverseMap();
            CreateMap<CampaignResponseDto, CampaignEntity>().ReverseMap();

            CreateMap<CampaignItemEntity, CampaignItemRequestDto>().ReverseMap();
            CreateMap<CampaignItemEntity, CampaignItemResponseDto>().ReverseMap();
            CreateMap<CampaignItemRequestDto, CampaignItemEntity>().ReverseMap();
            CreateMap<CampaignItemResponseDto, CampaignItemEntity>().ReverseMap();

            CreateMap<CampaignServiceEntity, Domain.DataObjects.CMS.Request.CampaignServiceRequestDto>().ReverseMap();
            CreateMap<CampaignServiceEntity, CampaignServiceResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.CampaignServiceRequestDto, CampaignServiceEntity>().ReverseMap();
            CreateMap<CampaignServiceResponseDto, CampaignServiceEntity>().ReverseMap();

            CreateMap<CategoryEntity, CategoryRequestDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryResponseDto>().ReverseMap();
            CreateMap<CategoryRequestDto, CategoryEntity>().ReverseMap();
            CreateMap<CategoryResponseDto, CategoryEntity>().ReverseMap();

            CreateMap<CustomerEntity, CustomerRequestDto>().ReverseMap();
            CreateMap<CustomerEntity, CustomerResponseDto>().ReverseMap();
            CreateMap<CustomerRequestDto, CustomerEntity>().ReverseMap();
            CreateMap<CustomerResponseDto, CustomerEntity>().ReverseMap();

            CreateMap<DepartmentEntity, DepartmentRequestDto>().ReverseMap();
            CreateMap<DepartmentEntity, DepartmentResponseDto>().ReverseMap();
            CreateMap<DepartmentRequestDto, DepartmentEntity>().ReverseMap();
            CreateMap<DepartmentResponseDto, DepartmentEntity>().ReverseMap();

            CreateMap<DisclaimerEntity, DisclaimerRequestDto>().ReverseMap();
            CreateMap<DisclaimerEntity, DisclaimerResponseDto>().ReverseMap();
            CreateMap<DisclaimerRequestDto, DisclaimerEntity>().ReverseMap();
            CreateMap<DisclaimerResponseDto, DisclaimerEntity>().ReverseMap();

            CreateMap<ItemDetailEntity, ItemDetailRequestDto>().ReverseMap();
            CreateMap<ItemDetailEntity, ItemDetailResponseDto>().ReverseMap();
            CreateMap<ItemDetailRequestDto, ItemDetailEntity>().ReverseMap();
            CreateMap<ItemDetailResponseDto, ItemDetailEntity>().ReverseMap();

            CreateMap<ItemDisclaimerEntity, ItemDisclaimerRequestDto>().ReverseMap();
            CreateMap<ItemDisclaimerEntity, ItemDisclaimerResponseDto>().ReverseMap();
            CreateMap<ItemDisclaimerRequestDto, ItemDisclaimerEntity>().ReverseMap();
            CreateMap<ItemDisclaimerResponseDto, ItemDisclaimerEntity>().ReverseMap();

            CreateMap<ItemEntity, ItemRequestDto>().ReverseMap();
            CreateMap<ItemEntity, ItemResponseDto>().ReverseMap();
            CreateMap<ItemRequestDto, ItemEntity>().ReverseMap();
            CreateMap<ItemResponseDto, ItemEntity>().ReverseMap();

            CreateMap<MenuEntity, MenuRequestDto>().ReverseMap();
            CreateMap<MenuEntity, MenuResponseDto>().ReverseMap();
            CreateMap<MenuRequestDto, MenuEntity>().ReverseMap();
            CreateMap<MenuResponseDto, MenuEntity>().ReverseMap();

            CreateMap<MenuItemEntity, MenuItemRequestDto>().ReverseMap();
            CreateMap<MenuItemEntity, MenuItemResponseDto>().ReverseMap();
            CreateMap<MenuItemRequestDto, MenuItemEntity>().ReverseMap();
            CreateMap<MenuItemResponseDto, MenuItemEntity>().ReverseMap();

            CreateMap<MenuServiceEntity, Domain.DataObjects.CMS.Request.MenuServiceRequestDto>().ReverseMap();
            CreateMap<MenuServiceEntity, MenuServiceResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.MenuServiceRequestDto, MenuServiceEntity>().ReverseMap();
            CreateMap<MenuServiceResponseDto, MenuServiceEntity>().ReverseMap();

            CreateMap<MenuTemplateEntity, MenuTemplateRequestDto>().ReverseMap();
            CreateMap<MenuTemplateEntity, MenuTemplateResponseDto>().ReverseMap();
            CreateMap<MenuTemplateRequestDto, MenuTemplateEntity>().ReverseMap();
            CreateMap<MenuTemplateResponseDto, MenuTemplateEntity>().ReverseMap();

            CreateMap<ReportEntity, ReportRequestDto>().ReverseMap();
            CreateMap<ReportEntity, ReportResponseDto>().ReverseMap();
            CreateMap<ReportRequestDto, ReportEntity>().ReverseMap();
            CreateMap<ReportResponseDto, ReportEntity>().ReverseMap();

            CreateMap<ReportTemplateEntity, ReportTemplateRequestDto>().ReverseMap();
            CreateMap<ReportTemplateEntity, ReportTemplateResponseDto>().ReverseMap();
            CreateMap<ReportTemplateRequestDto, ReportTemplateEntity>().ReverseMap();
            CreateMap<ReportTemplateResponseDto, ReportTemplateEntity>().ReverseMap();

            CreateMap<OrderEntity, OrderRequestDto>().ReverseMap();
            CreateMap<OrderEntity, OrderResponseDto>().ReverseMap();
            CreateMap<OrderRequestDto, OrderEntity>().ReverseMap();
            CreateMap<OrderResponseDto, OrderEntity>().ReverseMap();

            CreateMap<OrderItemEntity, Domain.DataObjects.CMS.Request.OrderItemRequestDto>().ReverseMap();
            CreateMap<OrderItemEntity, OrderItemResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.OrderItemRequestDto, OrderItemEntity>().ReverseMap();
            CreateMap<OrderItemResponseDto, OrderItemEntity>().ReverseMap();

            CreateMap<OrderStateEntity, Domain.DataObjects.CMS.Request.OrderStateRequestDto>().ReverseMap();
            CreateMap<OrderStateEntity, OrderStateResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.OrderStateRequestDto, OrderStateEntity>().ReverseMap();
            CreateMap<OrderStateResponseDto, OrderStateEntity>().ReverseMap();

            CreateMap<OrderServiceEntity, Domain.DataObjects.CMS.Request.OrderServiceRequestDto>().ReverseMap();
            CreateMap<OrderServiceEntity, OrderServiceResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.OrderServiceRequestDto, OrderServiceEntity>().ReverseMap();
            CreateMap<OrderServiceResponseDto, OrderServiceEntity>().ReverseMap();

            CreateMap<StoreEntity, StoreRequestDto>().ReverseMap();
            CreateMap<StoreEntity, StoreResponseDto>().ReverseMap();
            CreateMap<StoreRequestDto, StoreEntity>().ReverseMap();
            CreateMap<StoreResponseDto, StoreEntity>().ReverseMap();

            CreateMap<StoreServiceEntity, Domain.DataObjects.CMS.Request.StoreServiceRequestDto>().ReverseMap();
            CreateMap<StoreServiceEntity, StoreServiceResponseDto>().ReverseMap();
            CreateMap<Domain.DataObjects.CMS.Request.StoreServiceRequestDto, StoreServiceEntity>().ReverseMap();
            CreateMap<StoreServiceResponseDto, StoreServiceEntity>().ReverseMap();

            CreateMap<AuditHistoricalEntity, AuditHistoricalRequestDto>().ReverseMap();
            CreateMap<AuditHistoricalEntity, AuditHistoricalResponseDto>().ReverseMap();
            CreateMap<AuditHistoricalRequestDto, AuditHistoricalEntity>().ReverseMap();
            CreateMap<AuditHistoricalResponseDto, AuditHistoricalEntity>().ReverseMap();
        }
    }
}
