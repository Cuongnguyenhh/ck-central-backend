using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.GrabMart.Store.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Store.Abstract.Repositories
{
    public interface IStoreHistoricalRepository : IBaseRepository<StoreHistoricalEntity>
    {
    }
}
