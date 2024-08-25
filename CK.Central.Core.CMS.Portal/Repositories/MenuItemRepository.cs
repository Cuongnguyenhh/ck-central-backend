using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.CMS.Portal.DbContexts;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Abstract.Repositories;
using EFCore.BulkExtensions;

namespace CK.Central.Core.CMS.Portal.Repositories
{
    public class MenuItemRepository : BaseRepository<MenuItemEntity>, IMenuItemRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MenuItemRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
        public async Task<bool> InsertMany(List<MenuItemEntity> entities)
        {
            if (entities == null || !entities.Any())
            {
                return false;
            }

            foreach (var entity in entities)
            {
                entity.PK_UUID = Guid.NewGuid();
                entity.IsActive = true;
                entity.IsDeleted = false;
                entity.CreatedBy = entity.CreatedBy;
                entity.CreatedDatetime = DateTime.Now;

                entity.ContentPayloadJson = string.IsNullOrEmpty(entity.ContentPayloadJson) ? "{}" : entity.ContentPayloadJson;
                entity.ContentRequestJson = string.IsNullOrEmpty(entity.ContentRequestJson) ? "{}" : entity.ContentRequestJson;
                entity.ContentResponseJson = string.IsNullOrEmpty(entity.ContentResponseJson) ? "{}" : entity.ContentResponseJson;
            }
            await _masterContext.BulkInsertAsync(entities);
            return true;
        }
    }

}
