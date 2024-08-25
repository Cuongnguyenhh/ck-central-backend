using AutoMapper;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Request;
using CK.Central.Core.Domain.DataObjects.GrabMart.Response;

namespace CK.Central.Core.GrabMart.Authorisation.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<AuthorisationActivityEntity, AuthorisationActivityRequestDto>().ReverseMap();
            CreateMap<AuthorisationActivityEntity, AuthorisationActivityResponseDto>().ReverseMap();
            CreateMap<AuthorisationActivityRequestDto, AuthorisationActivityEntity>().ReverseMap();
            CreateMap<AuthorisationActivityResponseDto, AuthorisationActivityEntity>().ReverseMap();

            CreateMap<AuthorisationCredentialsEntity, AuthorisationCredentialsRequestDto>().ReverseMap();
            CreateMap<AuthorisationCredentialsEntity, AuthorisationActivityResponseDto>().ReverseMap();
            CreateMap<AuthorisationCredentialsRequestDto, AuthorisationCredentialsEntity>().ReverseMap();
            CreateMap<AuthorisationCredentialsResponseDto, AuthorisationCredentialsEntity>().ReverseMap();

            CreateMap<AuthorisationHistoricalEntity, AuthorisationHistoricalRequestDto>().ReverseMap();
            CreateMap<AuthorisationHistoricalEntity, AuthorisationHistoricalResponseDto>().ReverseMap();
            CreateMap<AuthorisationHistoricalRequestDto, AuthorisationHistoricalEntity>().ReverseMap();
            CreateMap<AuthorisationHistoricalResponseDto, AuthorisationHistoricalEntity>().ReverseMap();

            CreateMap<AuthorisationServiceEntity, AuthorisationServiceRequestDto>().ReverseMap();
            CreateMap<AuthorisationServiceEntity, AuthorisationServiceResponseDto>().ReverseMap();
            CreateMap<AuthorisationServiceRequestDto, AuthorisationServiceEntity>().ReverseMap();
            CreateMap<AuthorisationServiceResponseDto, AuthorisationServiceEntity>().ReverseMap();

            CreateMap<AuthorisationTokenEntity, AuthorisationTokenRequestDto>().ReverseMap();
            CreateMap<AuthorisationTokenEntity, AuthorisationTokenResponseDto>().ReverseMap();
            CreateMap<AuthorisationTokenRequestDto, AuthorisationTokenEntity>().ReverseMap();
            CreateMap<AuthorisationTokenResponseDto, AuthorisationTokenEntity>().ReverseMap();

        }
    }
}
