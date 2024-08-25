using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.Abstract.Repositories
{
    public interface IIdentityRoleClaimRepository
    {
        Task<List<AspNetRoleClaimEntity>> GetAll();

        Task<AspNetRoleClaimEntity> Get(int Id);

        Task<List<AspNetRoleClaimEntity>> GetByRoleId(string RoleId);

    }
}
