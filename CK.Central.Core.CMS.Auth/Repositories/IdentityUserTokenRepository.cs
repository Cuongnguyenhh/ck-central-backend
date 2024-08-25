using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.CMS.Auth.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Auth.Repositories
{
    public class IdentityUserTokenRepository : IIdentityUserTokenRepository
    {
        private readonly IMasterDbContext _masterContext;
        private readonly ISlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public IdentityUserTokenRepository(IMasterDbContext masterContext,
            ISlaveDbContext slaveDbContext, IOptions<MongoDbSettingsModel> mongoDbOptions)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<AspNetUserTokenEntity>> GetAll()
        {
            return await _slaveDbContext.AspNetUserTokens.AsNoTracking().ToListAsync();
        }

        public async Task<List<AspNetUserTokenEntity>> GetByUserId(string UserId)
        {
            return await _slaveDbContext.AspNetUserTokens.AsNoTracking().Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}
