using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.POS.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.POS.GrabMart.Order.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<OrderActivityEntity>();
            modelBuilder.ApplyConfiguration(new OrderActivityConfiguration());

            modelBuilder.Entity<OrderCustomerEntity>();
            modelBuilder.ApplyConfiguration(new OrderCustomerConfiguration());

            modelBuilder.Entity<OrderHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new OrderHistoricalConfiguration());

            modelBuilder.Entity<OrderInvoiceEntity>();
            modelBuilder.ApplyConfiguration(new OrderInvoiceConfiguration());

            modelBuilder.Entity<OrderItemEntity>();
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.Entity<OrderServiceEntity>();
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());

            modelBuilder.Entity<OrderSubmitEntity>();
            modelBuilder.ApplyConfiguration(new OrderSubmitConfiguration());

            modelBuilder.Entity<OrderUpdateEntity>();
            modelBuilder.ApplyConfiguration(new OrderUpdateConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
