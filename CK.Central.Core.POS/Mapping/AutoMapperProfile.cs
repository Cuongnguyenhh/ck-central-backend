using AutoMapper;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.Domain.DataObjects.Shared.Request;
using CK.Central.Core.Domain.DataObjects.Shared.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GeneralActivityEntity, GeneralActivityRequestDto>().ReverseMap();
            CreateMap<GeneralActivityEntity, GeneralActivityResponseDto>().ReverseMap();
            CreateMap<GeneralActivityRequestDto, GeneralActivityEntity>().ReverseMap();
            CreateMap<GeneralActivityResponseDto, GeneralActivityEntity>().ReverseMap();

            CreateMap<GeneralCommandEntity, GeneralCommandRequestDto>().ReverseMap();
            CreateMap<GeneralCommandEntity, GeneralCommandResponseDto>().ReverseMap();
            CreateMap<GeneralCommandRequestDto, GeneralCommandEntity>().ReverseMap();
            CreateMap<GeneralCommandResponseDto, GeneralCommandEntity>().ReverseMap();

            CreateMap<GeneralHistoricalEntity, GeneralHistoricalRequestDto>().ReverseMap();
            CreateMap<GeneralHistoricalEntity, GeneralHistoricalResponseDto>().ReverseMap();
            CreateMap<GeneralHistoricalRequestDto, GeneralHistoricalEntity>().ReverseMap();
            CreateMap<GeneralHistoricalResponseDto, GeneralHistoricalEntity>().ReverseMap();

            CreateMap<GeneralPipelineEntity, GeneralPipelineRequestDto>().ReverseMap();
            CreateMap<GeneralPipelineEntity, GeneralPipelineResponseDto>().ReverseMap();
            CreateMap<GeneralPipelineRequestDto, GeneralPipelineEntity>().ReverseMap();
            CreateMap<GeneralPipelineResponseDto, GeneralPipelineEntity>().ReverseMap();
        }
    }
}
