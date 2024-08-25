using Microsoft.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CK.Central.Core.CMS.Generate.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<GenerationActivityEntity> GenerationActivities => Set<GenerationActivityEntity>();
        public DbSet<GenerationHistoricalEntity> GenerationHistoricals => Set<GenerationHistoricalEntity>();
        public DbSet<GenerationPipelineEntity> GenerationPipelines => Set<GenerationPipelineEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GenerationActivityEntity>().ToCollection<GenerationActivityEntity>("GenerationActivityCollection");
            modelBuilder.Entity<GenerationHistoricalEntity>().ToCollection<GenerationHistoricalEntity>("GenerationHistoricalCollection");
            modelBuilder.Entity<GenerationPipelineEntity>().ToCollection<GenerationPipelineEntity>("GenerationPipelineCollection");
        }
    }
}
