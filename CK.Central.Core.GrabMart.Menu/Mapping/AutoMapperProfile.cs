using AutoMapper;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Menu.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<MenuActivityEntity, MenuActivityRequestDto>().ReverseMap();
            CreateMap<MenuActivityEntity, MenuActivityResponseDto>().ReverseMap();
            CreateMap<MenuActivityRequestDto, MenuActivityEntity>().ReverseMap();
            CreateMap<MenuActivityResponseDto, MenuActivityEntity>().ReverseMap();

            CreateMap<MenuCategoriesEntity, MenuCategoriesRequestDto>().ReverseMap();
            CreateMap<MenuCategoriesEntity, MenuCategoriesResponseDto>().ReverseMap();
            CreateMap<MenuCategoriesRequestDto, MenuCategoriesEntity>().ReverseMap();
            CreateMap<MenuCategoriesResponseDto, MenuCategoriesEntity>().ReverseMap();

            CreateMap<MenuHistoricalEntity, MenuHistoricalRequestDto>().ReverseMap();
            CreateMap<MenuHistoricalEntity, MenuHistoricalResponseDto>().ReverseMap();
            CreateMap<MenuHistoricalRequestDto, MenuHistoricalEntity>().ReverseMap();
            CreateMap<MenuHistoricalResponseDto, MenuHistoricalEntity>().ReverseMap();

            CreateMap<MenuMartEntity, MenuMartRequestDto>().ReverseMap();
            CreateMap<MenuMartEntity, MenuMartResponseDto>().ReverseMap();
            CreateMap<MenuMartRequestDto, MenuMartEntity>().ReverseMap();
            CreateMap<MenuMartResponseDto, MenuMartEntity>().ReverseMap();

            CreateMap<MenuNotificationEntity, MenuNotificationRequestDto>().ReverseMap();
            CreateMap<MenuNotificationEntity, MenuNotificationResponseDto>().ReverseMap();
            CreateMap<MenuNotificationRequestDto, MenuNotificationEntity>().ReverseMap();
            CreateMap<MenuNotificationResponseDto, MenuNotificationEntity>().ReverseMap();

            CreateMap<MenuRecordEntity, MenuRecordRequestDto>().ReverseMap();
            CreateMap<MenuRecordEntity, MenuRecordResponseDto>().ReverseMap();
            CreateMap<MenuRecordRequestDto, MenuRecordEntity>().ReverseMap();
            CreateMap<MenuRecordResponseDto, MenuRecordEntity>().ReverseMap();

            CreateMap<MenuSellingTimeEntity, MenuSellingTimeRequestDto>().ReverseMap();
            CreateMap<MenuSellingTimeEntity, MenuSellingTimeResponseDto>().ReverseMap();
            CreateMap<MenuSellingTimeRequestDto, MenuSellingTimeEntity>().ReverseMap();
            CreateMap<MenuSellingTimeResponseDto, MenuSellingTimeEntity>().ReverseMap();

            CreateMap<MenuServiceEntity, MenuServiceRequestDto>().ReverseMap();
            CreateMap<MenuServiceEntity, MenuServiceResponseDto>().ReverseMap();
            CreateMap<MenuServiceRequestDto, MenuServiceEntity>().ReverseMap();
            CreateMap<MenuServiceResponseDto, MenuServiceEntity>().ReverseMap();

            CreateMap<MenuSyncWebhookEntity, MenuSyncWebhookRequestDto>().ReverseMap();
            CreateMap<MenuSyncWebhookEntity, MenuSyncWebhookResponseDto>().ReverseMap();
            CreateMap<MenuSyncWebhookRequestDto, MenuSyncWebhookEntity>().ReverseMap();
            CreateMap<MenuSyncWebhookResponseDto, MenuSyncWebhookEntity>().ReverseMap();
        }
    }
}
