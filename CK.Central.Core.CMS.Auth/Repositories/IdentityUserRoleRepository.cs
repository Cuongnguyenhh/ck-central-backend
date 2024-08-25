using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.Extensions.Options;
using CK.Central.Core.CMS.Auth.DbContexts;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Auth.Repositories
{
    public class IdentityUserRoleRepository : IIdentityUserRoleRepository
    {
        private readonly IMasterDbContext _masterContext;
        private readonly ISlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public IdentityUserRoleRepository(IMasterDbContext masterContext,
            ISlaveDbContext slaveDbContext, IOptions<MongoDbSettingsModel> mongoDbOptions)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<AspNetUserRoleEntity>> GetAll()
        {
            return await _slaveDbContext.AspNetUserRoles.AsNoTracking().ToListAsync();
        }

        public async Task<List<AspNetUserRoleEntity>> GetByRoleId(string RoleId)
        {
            return await _slaveDbContext.AspNetUserRoles.AsNoTracking().Where(x => x.RoleId == RoleId).ToListAsync();
        }

        public async Task<List<AspNetUserRoleEntity>> GetByUserId(string UserId)
        {
            return await _slaveDbContext.AspNetUserRoles.AsNoTracking().Where(x => x.UserId == UserId).ToListAsync();
        }
    }
}
