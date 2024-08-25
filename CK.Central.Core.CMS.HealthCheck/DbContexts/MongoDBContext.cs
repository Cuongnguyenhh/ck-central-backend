using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CK.Central.Core.CMS.HealthCheck.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        DbSet<HealthcheckActivityEntity> HealthcheckActivities => Set<HealthcheckActivityEntity>();
        DbSet<HealthcheckHistoricalEntity> HealthcheckHistoricals => Set<HealthcheckHistoricalEntity>();
        DbSet<HealthcheckIncidentEntity> HealthcheckIncidents => Set<HealthcheckIncidentEntity>();
        DbSet<HealthcheckPipelineEntity> HealthcheckPipelines => Set<HealthcheckPipelineEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<HealthcheckActivityEntity>().ToCollection<HealthcheckActivityEntity>("HealthcheckActivityCollection");
            modelBuilder.Entity<HealthcheckHistoricalEntity>().ToCollection<HealthcheckHistoricalEntity>("HealthcheckHistoricalCollection");
            modelBuilder.Entity<HealthcheckIncidentEntity>().ToCollection<HealthcheckIncidentEntity>("HealthcheckIncidentCollection");
            modelBuilder.Entity<HealthcheckPipelineEntity>().ToCollection<HealthcheckPipelineEntity>("HealthcheckPipelineCollection");
        }
    }
}
