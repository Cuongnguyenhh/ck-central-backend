using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.GrabMart.HealthCheck.DbContexts;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.GrabMart.HealthCheck.Abstract.Repositories;

namespace CK.Central.Core.GrabMart.HealthCheck.Repositories
{
    public class HealthcheckActivityRepository : BaseRepository<HealthcheckActivityEntity>, IHealthcheckActivityRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public HealthcheckActivityRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
