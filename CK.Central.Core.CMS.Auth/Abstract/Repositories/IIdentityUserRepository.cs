using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.Abstract.Repositories
{
    public interface IIdentityUserRepository
    {
        Task<List<AspNetUserEntity>> GetAll();

        Task<AspNetUserEntity> Get(string Id);
    }
}
