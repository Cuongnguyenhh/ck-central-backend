using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.DbContexts;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using StackExchange.Redis;

namespace CK.Central.Core.CMS.Auth.Repositories
{
    public class IdentityRoleClaimRepository: IIdentityRoleClaimRepository
    {
        private readonly IMasterDbContext _masterContext;
        private readonly ISlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public IdentityRoleClaimRepository(IMasterDbContext masterContext, 
            ISlaveDbContext slaveDbContext, IOptions<MongoDbSettingsModel> mongoDbOptions)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<List<AspNetRoleClaimEntity>> GetAll()
        {
            return await _slaveDbContext.AspNetRoleClaims.AsNoTracking().ToListAsync();
        }

        public async Task<AspNetRoleClaimEntity> Get(int Id)
        {
            return await _slaveDbContext.AspNetRoleClaims.AsNoTracking().FirstAsync(x => x.Id == Id);
        }

        public async Task<List<AspNetRoleClaimEntity>> GetByRoleId(string RoleId)
        {
            return await _slaveDbContext.AspNetRoleClaims.AsNoTracking().Where(x => x.RoleId == RoleId).ToListAsync();
        }
    }
}
