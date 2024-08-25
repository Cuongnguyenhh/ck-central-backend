using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Portal.Abstract.Repositories
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {
        Task<List<OrderEntity>> GetAllOrdersAsync();

        Task<List<OrderEntity>> GetAllOrdersActiveAsync();

        Task<OrderEntity> GetOrderByIdAsync(Guid Id);

        Task<OrderEntity> GetOrderActiveByIdAsync(Guid Id);

        Task<bool> DeleteOrderByIdAsync(Guid Id);
    }
}
