using AutoMapper;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;

namespace CK.Central.Core.GrabMart.Campaign.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CampaignActivityEntity, CampaignActivityRequestDto>().ReverseMap();
            CreateMap<CampaignActivityEntity, CampaignActivityResponseDto>().ReverseMap();
            CreateMap<CampaignActivityRequestDto, CampaignActivityEntity>().ReverseMap();
            CreateMap<CampaignActivityResponseDto, CampaignActivityEntity>().ReverseMap();

            CreateMap<CampaignHistoricalEntity, CampaignHistoricalRequestDto>().ReverseMap();
            CreateMap<CampaignHistoricalEntity, CampaignHistoricalResponseDto>().ReverseMap();
            CreateMap<CampaignHistoricalRequestDto, CampaignHistoricalEntity>().ReverseMap();
            CreateMap<CampaignHistoricalResponseDto, CampaignHistoricalEntity>().ReverseMap();

            CreateMap<CampaignListEntity, CampaignListRequestDto>().ReverseMap();
            CreateMap<CampaignListEntity, CampaignListResponseDto>().ReverseMap();
            CreateMap<CampaignListRequestDto, CampaignListEntity>().ReverseMap();
            CreateMap<CampaignListResponseDto, CampaignListEntity>().ReverseMap();

            CreateMap<CampaignOngoingEntity, CampaignOngoingRequestDto>().ReverseMap();
            CreateMap<CampaignOngoingEntity, CampaignOngoingResponseDto>().ReverseMap();
            CreateMap<CampaignOngoingRequestDto, CampaignOngoingEntity>().ReverseMap();
            CreateMap<CampaignOngoingResponseDto, CampaignOngoingEntity>().ReverseMap();

            CreateMap<CampaignServiceEntity, CampaignServiceRequestDto>().ReverseMap();
            CreateMap<CampaignServiceEntity, CampaignServiceResponseDto>().ReverseMap();
            CreateMap<CampaignServiceRequestDto, CampaignServiceEntity>().ReverseMap();
            CreateMap<CampaignServiceResponseDto, CampaignServiceEntity>().ReverseMap();

            CreateMap<CampaignUpcomingEntity, CampaignUpcomingRequestDto>().ReverseMap();
            CreateMap<CampaignUpcomingEntity, CampaignUpcomingResponseDto>().ReverseMap();
            CreateMap<CampaignUpcomingRequestDto, CampaignUpcomingEntity>().ReverseMap();
            CreateMap<CampaignUpcomingResponseDto, CampaignUpcomingEntity>().ReverseMap();
        }
    }
}
