using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Store.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        public virtual DbSet<StoreActivityEntity> StoreActivities { get; set; }
        public virtual DbSet<StoreDeliveryHoursEntity> StoreDeliveryHours { get; set; }
        public virtual DbSet<StoreHistoricalEntity> StoreHistoricals { get; set; }
        public virtual DbSet<StoreHoursEntity> StoreHours { get; set; }
        public virtual DbSet<StorePauseEntity> StorePauses { get; set; }
        public virtual DbSet<StoreServiceEntity> StoreServices { get; set; }
        public virtual DbSet<StoreSpecialHoursEntity> StoreSpecialHours { get; set; }
        public virtual DbSet<StoreStatusEntity> StoreStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<StoreActivityEntity>();
            modelBuilder.ApplyConfiguration(new StoreActivityConfiguration());

            modelBuilder.Entity<StoreDeliveryHoursEntity>();
            modelBuilder.ApplyConfiguration(new StoreDeliveryHoursConfiguration());

            modelBuilder.Entity<StoreHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new StoreHistoricalConfiguration());

            modelBuilder.Entity<StoreHoursEntity>();
            modelBuilder.ApplyConfiguration(new StoreHoursConfiguration());

            modelBuilder.Entity<StorePauseEntity>();
            modelBuilder.ApplyConfiguration(new StorePauseConfiguration());

            modelBuilder.Entity<StoreServiceEntity>();
            modelBuilder.ApplyConfiguration(new StoreServiceConfiguration());

            modelBuilder.Entity<StoreSpecialHoursEntity>();
            modelBuilder.ApplyConfiguration(new StoreSpecialHoursConfiguration());

            modelBuilder.Entity<StoreStatusEntity>();
            modelBuilder.ApplyConfiguration(new StoreStatusConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
