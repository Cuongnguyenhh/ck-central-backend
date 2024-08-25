using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Elastic.Clients.Elasticsearch.Fluent;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.Shared.Response
{
    public class GeneralHistoricalResponseDto : BaseResponseDto
    {
        public GeneralHistoricalResponseDto() { }
        public GeneralHistoricalResponseDto(GeneralHistoricalEntity entity)
        {
            PK_UUID = entity.PK_UUID;
            Parent_UUID = entity.Parent_UUID;
            Name = entity.Name;
            Code = entity.Code;
            Description = entity.Description;
            IsActive = entity.IsActive;
            IsDeleted = entity.IsDeleted;
            CreatedBy = entity.CreatedBy;
            CreatedDatetime = entity.CreatedDatetime;
            UpdatedBy = entity.UpdatedBy;
            UpdatedDatetime = entity.UpdatedDatetime;
            DeletedBy = entity.DeletedBy;
            DeletedDatetime = entity.DeletedDatetime;
        }
    }
}
