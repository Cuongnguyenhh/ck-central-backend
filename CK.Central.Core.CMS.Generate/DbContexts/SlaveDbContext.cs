using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Configuration;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Generate.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<GenerationActivityEntity> GenerationActivities { get; set; }
        public virtual DbSet<GenerationHistoricalEntity> GenerationHistoricals { get; set; }
        public virtual DbSet<GenerationPipelineEntity> GenerationPipelines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<GenerationActivityEntity>();
            modelBuilder.ApplyConfiguration(new GenerationActivityConfiguration());

            modelBuilder.Entity<GenerationHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new GenerationHistoricalConfiguration());

            modelBuilder.Entity<GenerationPipelineEntity>();
            modelBuilder.ApplyConfiguration(new GenerationPipelineConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
