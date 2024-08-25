using CK.Central.Core.Domain.DataObjects.POS.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace CK.Central.Core.POS.GrabMart.Order.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<OrderActivityEntity> OrderActivities => Set<OrderActivityEntity>();
        public DbSet<OrderCustomerEntity> OrderCustomers => Set<OrderCustomerEntity>();
        public DbSet<OrderHistoricalEntity> OrderHistoricals => Set<OrderHistoricalEntity>();
        public DbSet<OrderInvoiceEntity> OrderInvoices => Set<OrderInvoiceEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<OrderServiceEntity> OrderServices => Set<OrderServiceEntity>();
        public DbSet<OrderSubmitEntity> OrderSubmits => Set<OrderSubmitEntity>();
        public DbSet<OrderUpdateEntity> OrderUpdates => Set<OrderUpdateEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderActivityEntity>().ToCollection<OrderActivityEntity>("OrderActivityCollection");

            modelBuilder.Entity<OrderCustomerEntity>().ToCollection<OrderCustomerEntity>("OrderCustomerCollection");

            modelBuilder.Entity<OrderHistoricalEntity>().ToCollection<OrderHistoricalEntity>("OrderHistoricalCollection");

            modelBuilder.Entity<OrderInvoiceEntity>().ToCollection<OrderInvoiceEntity>("OrderInvoiceCollection");

            modelBuilder.Entity<OrderItemEntity>().ToCollection<OrderItemEntity>("OrderItemCollection");

            modelBuilder.Entity<OrderServiceEntity>().ToCollection<OrderServiceEntity>("OrderServiceCollection");

            modelBuilder.Entity<OrderSubmitEntity>().ToCollection<OrderSubmitEntity>("OrderSubmitCollection");

            modelBuilder.Entity<OrderUpdateEntity>().ToCollection<OrderUpdateEntity>("OrderUpdateCollection");
        }
    }
}
