using AutoMapper;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Request;
using CK.Central.Core.Domain.DataObjects.CMS.Response;

namespace CK.Central.Core.CMS.Generate.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenerationHistoricalEntity, GenerationHistoricalRequestDto>().ReverseMap();
            CreateMap<GenerationHistoricalEntity, GenerationHistoricalResponseDto>().ReverseMap();
            CreateMap<GenerationHistoricalRequestDto, GenerationHistoricalEntity>().ReverseMap();
            CreateMap<GenerationHistoricalResponseDto, GenerationHistoricalEntity>().ReverseMap();

            CreateMap<GenerationActivityEntity, GenerationActivityRequestDto>().ReverseMap();
            CreateMap<GenerationActivityEntity, GenerationActivityResponseDto>().ReverseMap();
            CreateMap<GenerationActivityRequestDto, GenerationActivityEntity>().ReverseMap();
            CreateMap<GenerationActivityResponseDto, GenerationActivityEntity>().ReverseMap();

            CreateMap<GenerationPipelineEntity, GenerationPipelineRequestDto>().ReverseMap();
            CreateMap<GenerationPipelineEntity, GenerationPipelineResponseDto>().ReverseMap();
            CreateMap<GenerationPipelineRequestDto, GenerationPipelineEntity>().ReverseMap();
            CreateMap<GenerationPipelineResponseDto, GenerationPipelineEntity>().ReverseMap();
        }
    }
}
