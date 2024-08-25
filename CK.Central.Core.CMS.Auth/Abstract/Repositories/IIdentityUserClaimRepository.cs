using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.Abstract.Repositories
{
    public interface IIdentityUserClaimRepository
    {
        Task<List<AspNetUserClaimEntity>> GetAll();

        Task<AspNetUserClaimEntity> Get(int Id);

        Task<List<AspNetUserClaimEntity>> GetByUserId(string UserId);
    }
}
