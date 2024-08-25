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

namespace CK.Central.Core.CMS.Job.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskActivityEntity, TaskActivityRequestDto>().ReverseMap();
            CreateMap<TaskActivityEntity, TaskActivityResponseDto>().ReverseMap();
            CreateMap<TaskActivityRequestDto, TaskActivityEntity>().ReverseMap();
            CreateMap<TaskActivityResponseDto, TaskActivityEntity>().ReverseMap();

            CreateMap<TaskHistoricalEntity, TaskHistoricalRequestDto>().ReverseMap();
            CreateMap<TaskHistoricalEntity, TaskHistoricalResponseDto>().ReverseMap();
            CreateMap<TaskHistoricalRequestDto, TaskHistoricalEntity>().ReverseMap();
            CreateMap<TaskHistoricalResponseDto, TaskHistoricalEntity>().ReverseMap();

            CreateMap<TaskPipelineEntity, TaskPipelineRequestDto>().ReverseMap();
            CreateMap<TaskPipelineEntity, TaskPipelineResponseDto>().ReverseMap();
            CreateMap<TaskPipelineRequestDto, TaskPipelineEntity>().ReverseMap();
            CreateMap<TaskPipelineResponseDto, TaskPipelineEntity>().ReverseMap();

            CreateMap<TaskHandledEntity, TaskHandledRequestDto>().ReverseMap();
            CreateMap<TaskHandledEntity, TaskHandledResponseDto>().ReverseMap();
            CreateMap<TaskHandledRequestDto, TaskHandledEntity>().ReverseMap();
            CreateMap<TaskHandledResponseDto, TaskHandledEntity>().ReverseMap();

            CreateMap<JobActivityEntity, JobActivityRequestDto>().ReverseMap();
            CreateMap<JobActivityEntity, JobActivityResponseDto>().ReverseMap();
            CreateMap<JobActivityRequestDto, JobActivityEntity>().ReverseMap();
            CreateMap<JobActivityResponseDto, JobActivityEntity>().ReverseMap();

            CreateMap<JobHistoricalEntity, JobHistoricalRequestDto>().ReverseMap();
            CreateMap<JobHistoricalEntity, JobHistoricalResponseDto>().ReverseMap();
            CreateMap<JobHistoricalRequestDto, JobHistoricalEntity>().ReverseMap();
            CreateMap<JobHistoricalResponseDto, JobHistoricalEntity>().ReverseMap();

            CreateMap<JobPipelineEntity, JobPipelineRequestDto>().ReverseMap();
            CreateMap<JobPipelineEntity, JobPipelineResponseDto>().ReverseMap();
            CreateMap<JobPipelineRequestDto, JobPipelineEntity>().ReverseMap();
            CreateMap<JobPipelineResponseDto, JobPipelineEntity>().ReverseMap();
        }
    }
}
