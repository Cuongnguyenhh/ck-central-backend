using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Order.DbContexts
{
    public class SlaveDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        public virtual DbSet<OrderActivityEntity> OrderActivities { get; set; }
        public virtual DbSet<OrderCampaignEntity> OrderCampaigns { get; set; }
        public virtual DbSet<OrderCampaignItemEntity> OrderCampaignItems { get; set; }
        public virtual DbSet<OrderCancelableEntity> OrderCancelables { get; set; }
        public virtual DbSet<OrderHistoricalEntity> OrderHistoricals { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
        public virtual DbSet<OrderItemModifierEntity> OrderItemModifiers { get; set; }
        public virtual DbSet<OrderListEntity> OrderLists { get; set; }
        public virtual DbSet<OrderPriceEntity> OrderPrices { get; set; }
        public virtual DbSet<OrderPromotionEntity> OrderPromotions { get; set; }
        public virtual DbSet<OrderReadyEntity> OrderReadies { get; set; }
        public virtual DbSet<OrderReadyEstimationEntity> OrderReadyEstimations { get; set; }
        public virtual DbSet<OrderReceiverEntity> OrderReceivers { get; set; }
        public virtual DbSet<OrderServiceEntity> OrderServices { get; set; }
        public virtual DbSet<OrderStateEntity> OrderStates { get; set; }
        public virtual DbSet<OrderSubmitEntity> OrderSubmits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<OrderActivityEntity>();
            modelBuilder.ApplyConfiguration(new OrderActivityConfiguration());

            modelBuilder.Entity<OrderCampaignEntity>();
            modelBuilder.ApplyConfiguration(new OrderCampaignConfiguration());

            modelBuilder.Entity<OrderCampaignItemEntity>();
            modelBuilder.ApplyConfiguration(new OrderCampaignItemConfiguration());

            modelBuilder.Entity<OrderCancelableEntity>();
            modelBuilder.ApplyConfiguration(new OrderCancelableConfiguration());

            modelBuilder.Entity<OrderHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new OrderHistoricalConfiguration());

            modelBuilder.Entity<OrderItemEntity>();
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.Entity<OrderItemModifierEntity>();
            modelBuilder.ApplyConfiguration(new OrderItemModifierConfiguration());

            modelBuilder.Entity<OrderListEntity>();
            modelBuilder.ApplyConfiguration(new OrderListConfiguration());

            modelBuilder.Entity<OrderPriceEntity>();
            modelBuilder.ApplyConfiguration(new OrderPriceConfiguration());

            modelBuilder.Entity<OrderPromotionEntity>();
            modelBuilder.ApplyConfiguration(new OrderPromotionConfiguration());

            modelBuilder.Entity<OrderReadyEntity>();
            modelBuilder.ApplyConfiguration(new OrderReadyConfiguration());

            modelBuilder.Entity<OrderReadyEstimationEntity>();
            modelBuilder.ApplyConfiguration(new OrderReadyEstimationConfiguration());

            modelBuilder.Entity<OrderReceiverEntity>();
            modelBuilder.ApplyConfiguration(new OrderReceiverConfiguration());

            modelBuilder.Entity<OrderServiceEntity>();
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());

            modelBuilder.Entity<OrderStateEntity>();
            modelBuilder.ApplyConfiguration(new OrderStateConfiguration());

            modelBuilder.Entity<OrderSubmitEntity>();
            modelBuilder.ApplyConfiguration(new OrderSubmitConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
