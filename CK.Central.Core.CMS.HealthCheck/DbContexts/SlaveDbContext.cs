using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.Domain.DataObjects.Shared.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CK.Central.Core.CMS.HealthCheck.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<HealthcheckActivityEntity> HealthcheckActivities { get; set; }
        public virtual DbSet<HealthcheckHistoricalEntity> HealthcheckHistoricals { get; set; }
        public virtual DbSet<HealthcheckIncidentEntity> GetHealthcheckIncidents { get; set; }
        public virtual DbSet<HealthcheckPipelineEntity> HealthcheckPipelines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<HealthcheckActivityEntity>();
            modelBuilder.ApplyConfiguration(new HealthcheckActivityConfiguration());

            modelBuilder.Entity<HealthcheckHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new HealthcheckHistoricalConfiguration());

            modelBuilder.Entity<HealthcheckIncidentEntity>();
            modelBuilder.ApplyConfiguration(new HealthcheckIncidentConfiguration());

            modelBuilder.Entity<HealthcheckPipelineEntity>();
            modelBuilder.ApplyConfiguration(new HealthcheckPipelineConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
