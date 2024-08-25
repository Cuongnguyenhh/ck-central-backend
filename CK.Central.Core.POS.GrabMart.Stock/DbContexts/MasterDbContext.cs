using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.POS.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.POS.GrabMart.Stock.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
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
