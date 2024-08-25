using CK.Central.Core.DataObjects.Dto;
using Elastic.Clients.Elasticsearch.Fluent;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;

namespace CK.Central.Core.Domain.DataObjects.CMS.Request
{
    public class CampaignItemRequestDto : BaseRequestDto
    {
        public CampaignItemRequestDto() { }
        public CampaignItemRequestDto(CampaignItemEntity entity)
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
