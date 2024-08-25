using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Response
{
    public class AuthorisationTokenResponseDto : BaseResponseDto
    {
        public AuthorisationTokenResponseDto() { }
        public AuthorisationTokenResponseDto(AuthorisationTokenEntity entity)
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

    public class GrabOAuthTokenResponseDto
    {
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public int? expires_in { get; set; }
    }

    public class PartnerOAuthTokenResponseDto
    {
        public string? access_token { get; set; }
        public string? token_type { get; set; }
        public int? expires_in { get; set; }
    }
}
