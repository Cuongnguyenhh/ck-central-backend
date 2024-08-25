using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.GrabMart.Menu.Abstract.Repositories;
using CK.Central.Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.GrabMart.Menu.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.GrabMart.Menu.Repositories
{
    public class MenuServiceRepository : BaseRepository<MenuServiceEntity>, IMenuServiceRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MenuServiceRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
