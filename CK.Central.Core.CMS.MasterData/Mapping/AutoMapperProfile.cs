using AutoMapper;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.MasterData.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AreaEntity, AreaRequestDto>().ReverseMap();
            CreateMap<AreaEntity, AreaResponseDto>().ReverseMap();
            CreateMap<AreaRequestDto, AreaEntity>().ReverseMap();
            CreateMap<AreaResponseDto, AreaEntity>().ReverseMap();

            CreateMap<CityEntity, CityRequestDto>().ReverseMap();
            CreateMap<CityEntity, CityResponseDto>().ReverseMap();
            CreateMap<CityRequestDto, CityEntity>().ReverseMap();
            CreateMap<CityResponseDto, CityEntity>().ReverseMap();

            CreateMap<ConfigurationEntity, ConfigurationRequestDto>().ReverseMap();
            CreateMap<ConfigurationEntity, ConfigurationResponseDto>().ReverseMap();
            CreateMap<ConfigurationRequestDto, ConfigurationEntity>().ReverseMap();
            CreateMap<ConfigurationResponseDto, ConfigurationEntity>().ReverseMap();

            CreateMap<CountryEntity, CountryRequestDto>().ReverseMap();
            CreateMap<CountryEntity, CountryResponseDto>().ReverseMap();
            CreateMap<CountryRequestDto, CountryEntity>().ReverseMap();
            CreateMap<CountryResponseDto, CountryEntity>().ReverseMap();

            CreateMap<CurrencyEntity, CurrencyRequestDto>().ReverseMap();
            CreateMap<CurrencyEntity, CurrencyResponseDto>().ReverseMap();
            CreateMap<CurrencyRequestDto, CurrencyEntity>().ReverseMap();
            CreateMap<CurrencyResponseDto, CurrencyEntity>().ReverseMap();

            CreateMap<DefinitionEntity, DefinitionRequestDto>().ReverseMap();
            CreateMap<DefinitionEntity, DefinitionResponseDto>().ReverseMap();
            CreateMap<DefinitionRequestDto, DefinitionEntity>().ReverseMap();
            CreateMap<DefinitionResponseDto, DefinitionEntity>().ReverseMap();

            CreateMap<EmailEntity, EmailRequestDto>().ReverseMap();
            CreateMap<EmailEntity, EmailResponseDto>().ReverseMap();
            CreateMap<EmailRequestDto, EmailEntity>().ReverseMap();
            CreateMap<EmailResponseDto, EmailEntity>().ReverseMap();

            CreateMap<FileEntity, FileRequestDto>().ReverseMap();
            CreateMap<FileEntity, FileRequestDto>().ReverseMap();
            CreateMap<FileRequestDto, FileEntity>().ReverseMap();
            CreateMap<FileResponseDto, FileEntity>().ReverseMap();

            CreateMap<GroupEntity, GroupRequestDto>().ReverseMap();
            CreateMap<GroupEntity, GroupResponseDto>().ReverseMap();
            CreateMap<GroupRequestDto, GroupEntity>().ReverseMap();
            CreateMap<GroupResponseDto, GroupEntity>().ReverseMap();

            CreateMap<LanguageEntity, LanguageRequestDto>().ReverseMap();
            CreateMap<LanguageEntity, LanguageResponseDto>().ReverseMap();
            CreateMap<LanguageRequestDto, LanguageEntity>().ReverseMap();
            CreateMap<LanguageResponseDto, LanguageEntity>().ReverseMap();

            CreateMap<LinkEntity, LinkRequestDto>().ReverseMap();
            CreateMap<LinkEntity, LinkResponseDto>().ReverseMap();
            CreateMap<LinkRequestDto, LinkEntity>().ReverseMap();
            CreateMap<LinkResponseDto, LinkEntity>().ReverseMap();

            CreateMap<MessageEntity, MessageRequestDto>().ReverseMap();
            CreateMap<MessageEntity, MessageResponseDto>().ReverseMap();
            CreateMap<MessageRequestDto, MessageEntity>().ReverseMap();
            CreateMap<MessageResponseDto, MessageEntity>().ReverseMap();

            CreateMap<ProvinceEntity, ProvinceRequestDto>().ReverseMap();
            CreateMap<ProvinceEntity, ProvinceResponseDto>().ReverseMap();
            CreateMap<ProvinceRequestDto, ProvinceEntity>().ReverseMap();
            CreateMap<ProvinceResponseDto, ProvinceEntity>().ReverseMap();

            CreateMap<ServiceEntity, ServiceRequestDto>().ReverseMap();
            CreateMap<ServiceEntity, ServiceResponseDto>().ReverseMap();
            CreateMap<ServiceRequestDto, ServiceEntity>().ReverseMap();
            CreateMap<ServiceResponseDto, ServiceEntity>().ReverseMap();

            CreateMap<StatusEntity, StatusRequestDto>().ReverseMap();
            CreateMap<StatusEntity, StatusResponseDto>().ReverseMap();
            CreateMap<StatusRequestDto, StatusEntity>().ReverseMap();
            CreateMap<StatusResponseDto, StatusEntity>().ReverseMap();

            CreateMap<TokenEntity, TokenRequestDto>().ReverseMap();
            CreateMap<TokenEntity, TokenResponseDto>().ReverseMap();
            CreateMap<TokenRequestDto, TokenEntity>().ReverseMap();
            CreateMap<TokenResponseDto, TokenEntity>().ReverseMap();

            CreateMap<TypeEntity, TypeRequestDto>().ReverseMap();
            CreateMap<TypeEntity, TypeResponseDto>().ReverseMap();
            CreateMap<TypeRequestDto, TypeEntity>().ReverseMap();
            CreateMap<TypeResponseDto, TypeEntity>().ReverseMap();

            CreateMap<UnitEntity, UnitRequestDto>().ReverseMap();
            CreateMap<UnitEntity, UnitResponseDto>().ReverseMap();
            CreateMap<UnitRequestDto, UnitEntity>().ReverseMap();
            CreateMap<UnitResponseDto, UnitEntity>().ReverseMap();

            CreateMap<AuditHistoricalEntity, AuditHistoricalRequestDto>().ReverseMap();
            CreateMap<AuditHistoricalEntity, AuditHistoricalResponseDto>().ReverseMap();
            CreateMap<AuditHistoricalRequestDto, AuditHistoricalEntity>().ReverseMap();
            CreateMap<AuditHistoricalResponseDto, AuditHistoricalEntity>().ReverseMap();
        }
    }
}
