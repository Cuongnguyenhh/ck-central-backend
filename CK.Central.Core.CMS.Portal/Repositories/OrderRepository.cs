using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.CMS.Portal.DbContexts;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CK.Central.Core.CMS.Portal.Repositories
{
    public class OrderRepository : BaseRepository<OrderEntity>, IOrderRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public OrderRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<OrderEntity>> GetAllOrdersAsync()
        {
            return await _masterContext.Orders.Where(x => x.IsDeleted == false).AsNoTracking().ToListAsync();
        }

        public async Task<List<OrderEntity>> GetAllOrdersActiveAsync()
        {
            return await _masterContext.Orders.Where(x => x.IsDeleted == false && x.IsActive == true).AsNoTracking().ToListAsync();
        }

        public async Task<OrderEntity> GetOrderByIdAsync(Guid Id)
        {
            return await _masterContext.Orders.Where(x => x.IsDeleted == false && x.PK_UUID == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<OrderEntity> GetOrderActiveByIdAsync(Guid Id)
        {
            return await _masterContext.Orders.Where(x => x.IsDeleted == false && x.IsActive == true && x.PK_UUID == Id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteOrderByIdAsync(Guid Id)
        {
            var order = await _masterContext.Orders
                .Where(x => x.IsDeleted == false && x.IsActive == true && x.PK_UUID == Id)
                .FirstOrDefaultAsync();

            if (order == null) return false;

            order.IsDeleted = true;
            order.IsActive = false;
            order.DeletedDatetime = DateTime.Now;

            _masterContext.Update(order);
            await _masterContext.SaveChangesAsync();

            return true;
        }
    }
}
