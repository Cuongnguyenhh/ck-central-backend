using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Stock.DbContexts;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.POS.GrabMart.Stock.Repositories
{
    public class StockServiceRepository : BaseRepository<StockServiceEntity>, IStockServiceRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public StockServiceRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
