using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using CK.Central.Core.Domain.DataObjects.Shared.Configuration;

namespace CK.Central.Core.GrabMart.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        public virtual DbSet<GeneralActivityEntity> GeneralActivities { get; set; }
        public virtual DbSet<GeneralCommandEntity> GeneralCommands { get; set; }
        public virtual DbSet<GeneralHistoricalEntity> GeneralHistoricals { get; set; }
        public virtual DbSet<GeneralPipelineEntity> GeneralPipelines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<GeneralActivityEntity>();
            modelBuilder.ApplyConfiguration(new GeneralActivityConfiguration());

            modelBuilder.Entity<GeneralCommandEntity>();
            modelBuilder.ApplyConfiguration(new GeneralCommandConfiguration());

            modelBuilder.Entity<GeneralHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new GeneralHistoricalConfiguration());

            modelBuilder.Entity<GeneralPipelineEntity>();
            modelBuilder.ApplyConfiguration(new GeneralPipelineConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
