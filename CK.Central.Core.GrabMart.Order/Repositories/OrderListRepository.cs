using CK.Central.Core.GrabMart.Order.Abstract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.GrabMart.Order.DbContexts;
using CK.Central.Core.Repositories;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.GrabMart.Order.Repositories
{
    public class OrderListRepository : BaseRepository<OrderListEntity>, IOrderListRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public OrderListRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
