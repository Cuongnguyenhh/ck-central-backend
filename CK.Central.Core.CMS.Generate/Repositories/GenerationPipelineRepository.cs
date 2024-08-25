using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.CMS.Generate.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.CMS.Generate.DbContexts;

namespace CK.Central.Core.CMS.Generate.Repositories
{
    public class GenerationPipelineRepository : BaseRepository<GenerationPipelineEntity>, IGenerationPipelineRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public GenerationPipelineRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
