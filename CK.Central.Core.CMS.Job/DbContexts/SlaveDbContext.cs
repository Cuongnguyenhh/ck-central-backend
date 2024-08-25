using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.Shared.Configuration;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using System.Reflection;

namespace CK.Central.Core.CMS.Job.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<JobActivityEntity> JobActivities { get; set; }
        public virtual DbSet<JobHistoricalEntity> JobHistoricals { get; set; }
        public virtual DbSet<JobPipelineEntity> JobPipelines { get; set; }
        public virtual DbSet<TaskActivityEntity> TaskActivities { get; set; }
        public virtual DbSet<TaskHandledEntity> TaskHandleds { get; set; }
        public virtual DbSet<TaskHistoricalEntity> TaskHistoricals { get; set; }
        public virtual DbSet<TaskPipelineEntity> TaskPipelines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<JobActivityEntity>();
            modelBuilder.ApplyConfiguration(new JobActivityConfiguration());

            modelBuilder.Entity<JobHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new JobHistoricalConfiguration());

            modelBuilder.Entity<JobPipelineEntity>();
            modelBuilder.ApplyConfiguration(new JobPipelineConfiguration());

            modelBuilder.Entity<TaskActivityEntity>();
            modelBuilder.ApplyConfiguration(new TaskActivityConfiguration());

            modelBuilder.Entity<TaskHandledEntity>();
            modelBuilder.ApplyConfiguration(new TaskHandledConfiguration());

            modelBuilder.Entity<TaskHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new TaskHistoricalConfiguration());

            modelBuilder.Entity<TaskPipelineEntity>();
            modelBuilder.ApplyConfiguration(new TaskPipelineConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
