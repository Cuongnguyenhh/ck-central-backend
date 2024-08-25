using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.POS.Entity;
using CK.Central.Core.Domain.DataObjects.POS.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.GrabMart.Stock.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public DbSet<StockActivityEntity> StockActivities => Set<StockActivityEntity>();
        public DbSet<StockHistoricalEntity> StockHistoricals => Set<StockHistoricalEntity>();
        public DbSet<StockItemEntity> StockItems => Set<StockItemEntity>();
        public DbSet<StockServiceEntity> StockServices => Set<StockServiceEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<StockActivityEntity>();
            modelBuilder.ApplyConfiguration(new StockActivityConfiguration());

            modelBuilder.Entity<StockHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new StockHistoricalConfiguration());

            modelBuilder.Entity<StockItemEntity>();
            modelBuilder.ApplyConfiguration(new StockItemConfiguration());

            modelBuilder.Entity<StockServiceEntity>();
            modelBuilder.ApplyConfiguration(new StockServiceConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
