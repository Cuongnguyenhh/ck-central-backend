using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.GrabMart.Campaign.Abstract.Repositories;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.GrabMart.Campaign.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.GrabMart.Campaign.Repositories
{
    public class CampaignHistoricalRepository : BaseRepository<CampaignHistoricalEntity>, ICampaignHistoricalRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public CampaignHistoricalRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
