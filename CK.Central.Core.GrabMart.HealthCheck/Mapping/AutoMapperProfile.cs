using AutoMapper;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.Domain.DataObjects.Shared.Request;
using CK.Central.Core.Domain.DataObjects.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.HealthCheck.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<HealthcheckActivityEntity, HealthcheckActivityRequestDto>().ReverseMap();
            CreateMap<HealthcheckActivityEntity, HealthcheckActivityResponseDto>().ReverseMap();
            CreateMap<HealthcheckActivityRequestDto, HealthcheckActivityEntity>().ReverseMap();
            CreateMap<HealthcheckActivityResponseDto, HealthcheckActivityEntity>().ReverseMap();

            CreateMap<HealthcheckHistoricalEntity, HealthcheckHistoricalRequestDto>().ReverseMap();
            CreateMap<HealthcheckHistoricalEntity, HealthcheckHistoricalResponseDto>().ReverseMap();
            CreateMap<HealthcheckHistoricalRequestDto, HealthcheckHistoricalEntity>().ReverseMap();
            CreateMap<HealthcheckHistoricalResponseDto, HealthcheckHistoricalEntity>().ReverseMap();

            CreateMap<HealthcheckIncidentEntity, HealthcheckIncidentRequestDto>().ReverseMap();
            CreateMap<HealthcheckIncidentEntity, HealthcheckIncidentResponseDto>().ReverseMap();
            CreateMap<HealthcheckIncidentRequestDto, HealthcheckIncidentEntity>().ReverseMap();
            CreateMap<HealthcheckIncidentResponseDto, HealthcheckIncidentEntity>().ReverseMap();

            CreateMap<HealthcheckPipelineEntity, HealthcheckPipelineRequestDto>().ReverseMap();
            CreateMap<HealthcheckPipelineEntity, HealthcheckPipelineResponseDto>().ReverseMap();
            CreateMap<HealthcheckPipelineRequestDto, HealthcheckPipelineEntity>().ReverseMap();
            CreateMap<HealthcheckPipelineResponseDto, HealthcheckPipelineEntity>().ReverseMap();
        }
    }
}
