using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.CMS.Auth.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Auth.Repositories
{
    public class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly IMasterDbContext _masterContext;
        private readonly ISlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public IdentityUserRepository(IMasterDbContext masterContext,
            ISlaveDbContext slaveDbContext, IOptions<MongoDbSettingsModel> mongoDbOptions)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<AspNetUserEntity>> GetAll()
        {
            return await _slaveDbContext.AspNetUsers.AsNoTracking().ToListAsync();
        }

        public async Task<AspNetUserEntity> Get(string Id)
        {
            return await _slaveDbContext.AspNetUsers.AsNoTracking().FirstAsync(x => x.Id == Id);
        }
    }
}
