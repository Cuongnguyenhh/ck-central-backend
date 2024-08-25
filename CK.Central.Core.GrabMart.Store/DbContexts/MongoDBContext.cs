using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Store.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<StoreActivityEntity> StoreActivities => Set<StoreActivityEntity>();
        public DbSet<StoreDeliveryHoursEntity> StoreDeliveryHours => Set<StoreDeliveryHoursEntity>();
        public DbSet<StoreHistoricalEntity> StoreHistoricals => Set<StoreHistoricalEntity>();
        public DbSet<StoreHoursEntity> StoreHours => Set<StoreHoursEntity>();
        public DbSet<StorePauseEntity> StorePauses => Set<StorePauseEntity>();
        public DbSet<StoreServiceEntity> StoreServices => Set<StoreServiceEntity>();
        public DbSet<StoreSpecialHoursEntity> StoreSpecialHours => Set<StoreSpecialHoursEntity>();
        public DbSet<StoreStatusEntity> StoreStatuses => Set<StoreStatusEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StoreActivityEntity>().ToCollection<StoreActivityEntity>("StoreActivityCollection");

            modelBuilder.Entity<StoreDeliveryHoursEntity>().ToCollection<StoreDeliveryHoursEntity>("StoreDeliveryHoursCollection");

            modelBuilder.Entity<StoreHistoricalEntity>().ToCollection<StoreHistoricalEntity>("StoreHistoricalCollection");

            modelBuilder.Entity<StoreHoursEntity>().ToCollection<StoreHoursEntity>("StoreHoursCollection");

            modelBuilder.Entity<StorePauseEntity>().ToCollection<StorePauseEntity>("StorePauseCollection");

            modelBuilder.Entity<StoreServiceEntity>().ToCollection<StoreServiceEntity>("StoreServiceCollection");

            modelBuilder.Entity<StoreSpecialHoursEntity>().ToCollection<StoreSpecialHoursEntity>("StoreSpecialHoursCollection");

            modelBuilder.Entity<StoreStatusEntity>().ToCollection<StoreStatusEntity>("StoreStatusCollection");
        }
    }
}
