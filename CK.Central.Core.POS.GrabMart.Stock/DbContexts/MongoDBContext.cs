using CK.Central.Core.Domain.DataObjects.POS.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CK.Central.Core.POS.GrabMart.Stock.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<StockActivityEntity> StockActivities => Set<StockActivityEntity>();
        public DbSet<StockHistoricalEntity> StockHistoricals => Set<StockHistoricalEntity>();
        public DbSet<StockItemEntity> StockItems => Set<StockItemEntity>();
        public DbSet<StockServiceEntity> StockServices => Set<StockServiceEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockActivityEntity>().ToCollection<StockActivityEntity>("StockActivityCollection");
            modelBuilder.Entity<StockHistoricalEntity>().ToCollection<StockHistoricalEntity>("StockHistoricalCollection");
            modelBuilder.Entity<StockItemEntity>().ToCollection<StockItemEntity>("StockItemCollection");
            modelBuilder.Entity<StockServiceEntity>().ToCollection<StockServiceEntity>("StockServiceCollection");
        }
    }
}
