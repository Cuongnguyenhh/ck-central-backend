using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Authorisation.Abstract.Repositories
{
    public interface IAuthorisationCredentialsRepository : IBaseRepository<AuthorisationCredentialsEntity>
    {
    }
}
