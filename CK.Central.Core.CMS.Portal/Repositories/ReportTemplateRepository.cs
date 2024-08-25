using Castle.Core.Resource;
using CK.Central.Core.CMS.Portal.Abstract.Repositories;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.CMS.Portal.DbContexts;
using CK.Central.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Nest;
using Microsoft.AspNetCore.Http.HttpResults;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Abstract.Repositories;

namespace CK.Central.Core.CMS.Portal.Repositories
{
    public class ReportTemplateRepository : BaseRepository<ReportTemplateEntity>, IReportTemplateRepository
    {
        private readonly MasterDbContext _masterContext;
        private readonly SlaveDbContext _slaveDbContext;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public ReportTemplateRepository(IUnitOfWork context, MasterDbContext masterContext, SlaveDbContext slaveDbContext,
            IOptions<MongoDbSettingsModel> mongoDbOptions) : base(context, masterContext, slaveDbContext)
        {
            this._masterContext = masterContext;
            this._slaveDbContext = slaveDbContext;
            this._mongoClient = new MongoClient(mongoDbOptions.Value.ConnectionString);
            this._mongoDatabase = _mongoClient.GetDatabase(mongoDbOptions.Value.DatabaseName);
        }
    }
}
