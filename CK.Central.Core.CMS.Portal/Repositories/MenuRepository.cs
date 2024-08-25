using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.CMS.Portal.DbContexts;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.CMS.Portal.Repositories
{
    public class MenuRepository : BaseRepository<MenuEntity>, IMenuRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MenuRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }

        public async Task<Guid> Insert(MenuEntity entity)
        {
            if (entity.PK_UUID == new Guid("00000000-0000-0000-0000-000000000000"))
                entity.PK_UUID = Guid.NewGuid();

            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.CreatedBy = entity.CreatedBy;
            entity.CreatedDatetime = DateTime.Now;
            // Ensure JSON properties are initialized if null

            entity.ContentPayloadJson = string.IsNullOrEmpty(entity.ContentPayloadJson) ? "{}" : entity.ContentPayloadJson;
            entity.ContentRequestJson = string.IsNullOrEmpty(entity.ContentRequestJson) ? "{}" : entity.ContentRequestJson;
            entity.ContentResponseJson = string.IsNullOrEmpty(entity.ContentResponseJson) ? "{}" : entity.ContentResponseJson;


            await this._masterContext.AddAsync(entity);
            await this._masterContext.SaveChangesAsync();

            return entity.PK_UUID;
        }
    }
}
