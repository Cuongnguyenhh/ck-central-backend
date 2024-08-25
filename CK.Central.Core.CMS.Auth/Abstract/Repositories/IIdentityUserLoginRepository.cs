using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.Abstract.Repositories
{
    public interface IIdentityUserLoginRepository
    {
        Task<List<AspNetUserLoginEntity>> GetByUserId(string UserId);
    }
}
