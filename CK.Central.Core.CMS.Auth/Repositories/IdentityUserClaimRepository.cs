using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.CMS.Auth.DbContexts;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Auth.Repositories
{
    public class IdentityUserClaimRepository : IIdentityUserClaimRepository
    {
        private readonly IMasterDbContext _masterContext;
        private readonly ISlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public IdentityUserClaimRepository(IMasterDbContext masterContext,
            ISlaveDbContext slaveDbContext, IOptions<MongoDbSettingsModel> mongoDbOptions)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<AspNetUserClaimEntity>> GetAll()
        {
            return await _slaveDbContext.AspNetUserClaims.AsNoTracking().ToListAsync();
        }

        public async Task<AspNetUserClaimEntity> Get(int Id)
        {
            return await _slaveDbContext.AspNetUserClaims.AsNoTracking().FirstAsync(x => x.Id == Id);
        }

        public async Task<List<AspNetUserClaimEntity>> GetByUserId(string UserId)
        {
            return await _slaveDbContext.AspNetUserClaims.AsNoTracking().Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}
