using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Job.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        DbSet<JobActivityEntity> JobActivities => Set<JobActivityEntity>();
        DbSet<JobHistoricalEntity> JobHistoricals => Set<JobHistoricalEntity>();
        DbSet<JobPipelineEntity> JobPipelines => Set<JobPipelineEntity>();
        DbSet<TaskActivityEntity> TaskActivities => Set<TaskActivityEntity>();
        DbSet<TaskHandledEntity> TaskHandleds => Set<TaskHandledEntity>();
        DbSet<TaskHistoricalEntity> TaskHistoricals => Set<TaskHistoricalEntity>();
        DbSet<TaskPipelineEntity> TaskPipelines => Set<TaskPipelineEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobActivityEntity>().ToCollection<JobActivityEntity>("JobActivityCollection");
            modelBuilder.Entity<JobHistoricalEntity>().ToCollection<JobHistoricalEntity>("JobHistoricalCollection");
            modelBuilder.Entity<JobPipelineEntity>().ToCollection<JobPipelineEntity>("JobPipelineCollection");
            modelBuilder.Entity<TaskActivityEntity>().ToCollection<TaskActivityEntity>("TaskActivityCollection");
            modelBuilder.Entity<TaskHandledEntity>().ToCollection<TaskHandledEntity>("TaskHandledCollection");
            modelBuilder.Entity<TaskHistoricalEntity>().ToCollection<TaskHistoricalEntity>("TaskHistoricalCollection");
            modelBuilder.Entity<TaskPipelineEntity>().ToCollection<TaskPipelineEntity>("TaskPipelineCollection");
        }
    }
}
