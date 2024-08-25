using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Configuration;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Job.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
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

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false).Build();

            optionsBuilder.UseNpgsql(builder.GetConnectionString("MasterPgsqlDbConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
