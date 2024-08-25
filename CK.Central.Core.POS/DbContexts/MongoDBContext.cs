using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
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
