using AutoMapper;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;

namespace CK.Central.Core.GrabMart.Store.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StoreActivityEntity, StoreActivityRequestDto>().ReverseMap();
            CreateMap<StoreActivityEntity, StoreActivityResponseDto>().ReverseMap();
            CreateMap<StoreActivityRequestDto, StoreActivityEntity>().ReverseMap();
            CreateMap<StoreActivityResponseDto, StoreActivityEntity>().ReverseMap();

            CreateMap<StoreDeliveryHoursEntity, StoreDeliveryHoursRequestDto>().ReverseMap();
            CreateMap<StoreDeliveryHoursEntity, StoreDeliveryHoursResponseDto>().ReverseMap();
            CreateMap<StoreDeliveryHoursRequestDto, StoreDeliveryHoursEntity>().ReverseMap();
            CreateMap<StoreDeliveryHoursResponseDto, StoreDeliveryHoursEntity>().ReverseMap();

            CreateMap<StoreHistoricalEntity, StoreHistoricalRequestDto>().ReverseMap();
            CreateMap<StoreHistoricalEntity, StoreHistoricalResponseDto>().ReverseMap();
            CreateMap<StoreHistoricalRequestDto, StoreHistoricalEntity>().ReverseMap();
            CreateMap<StoreHistoricalResponseDto, StoreHistoricalEntity>().ReverseMap();

            CreateMap<StoreHoursEntity, StoreHoursRequestDto>().ReverseMap();
            CreateMap<StoreHoursEntity, StoreHoursResponseDto>().ReverseMap();
            CreateMap<StoreHoursRequestDto, StoreHoursEntity>().ReverseMap();
            CreateMap<StoreHoursResponseDto, StoreHoursEntity>().ReverseMap();

            CreateMap<StorePauseEntity, StorePauseRequestDto>().ReverseMap();
            CreateMap<StorePauseEntity, StorePauseResponseDto>().ReverseMap();
            CreateMap<StorePauseRequestDto, StorePauseEntity>().ReverseMap();
            CreateMap<StorePauseResponseDto, StorePauseEntity>().ReverseMap();

            CreateMap<StoreServiceEntity, StoreServiceRequestDto>().ReverseMap();
            CreateMap<StoreServiceEntity, StoreServiceResponseDto>().ReverseMap();
            CreateMap<StoreServiceRequestDto, StoreServiceEntity>().ReverseMap();
            CreateMap<StoreServiceResponseDto, StoreServiceEntity>().ReverseMap();

            CreateMap<StoreSpecialHoursEntity, StoreSpecialHoursRequestDto>().ReverseMap();
            CreateMap<StoreSpecialHoursEntity, StoreSpecialHoursResponseDto>().ReverseMap();
            CreateMap<StoreSpecialHoursRequestDto, StoreSpecialHoursEntity>().ReverseMap();
            CreateMap<StoreSpecialHoursResponseDto, StoreSpecialHoursEntity>().ReverseMap();

            CreateMap<StoreStatusEntity, StoreStatusRequestDto>().ReverseMap();
            CreateMap<StoreStatusEntity, StoreStatusResponseDto>().ReverseMap();
            CreateMap<StoreStatusRequestDto, StoreStatusEntity>().ReverseMap();
            CreateMap<StoreStatusResponseDto, StoreStatusEntity>().ReverseMap();
        }
    }
}
