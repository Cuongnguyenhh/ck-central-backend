using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CK.Central.Core.CMS.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {}

        public DbSet<GeneralActivityEntity> GeneralActivities => Set<GeneralActivityEntity>();
        public DbSet<GeneralCommandEntity> GeneralCommands => Set<GeneralCommandEntity>();
        public DbSet<GeneralHistoricalEntity> GeneralHistoricals => Set<GeneralHistoricalEntity>();
        public DbSet<GeneralPipelineEntity> GeneralPipelines => Set<GeneralPipelineEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GeneralActivityEntity>().ToCollection<GeneralActivityEntity>("GeneralActivityCollection");
            modelBuilder.Entity<GeneralCommandEntity>().ToCollection<GeneralCommandEntity>("GeneralCommandCollection");
            modelBuilder.Entity<GeneralHistoricalEntity>().ToCollection<GeneralHistoricalEntity>("GeneralHistoricalCollection");
            modelBuilder.Entity<GeneralPipelineEntity>().ToCollection<GeneralPipelineEntity>("GeneralPipelineCollection");
        }
    }
}
