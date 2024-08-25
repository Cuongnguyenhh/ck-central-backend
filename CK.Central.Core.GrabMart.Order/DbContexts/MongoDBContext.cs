using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Order.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<OrderActivityEntity> OrderActivities => Set<OrderActivityEntity>();
        public DbSet<OrderCampaignEntity> OrderCampaigns => Set<OrderCampaignEntity>();
        public DbSet<OrderCampaignItemEntity> OrderCampaignItems => Set<OrderCampaignItemEntity>();
        public DbSet<OrderCancelableEntity> OrderCancelables => Set<OrderCancelableEntity>();
        public DbSet<OrderHistoricalEntity> OrderHistoricals => Set<OrderHistoricalEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<OrderItemModifierEntity> OrderItemModifiers => Set<OrderItemModifierEntity>();
        public DbSet<OrderListEntity> OrderLists => Set<OrderListEntity>();
        public DbSet<OrderPriceEntity> OrderPrices => Set<OrderPriceEntity>();
        public DbSet<OrderPromotionEntity> OrderPromotions => Set<OrderPromotionEntity>();
        public DbSet<OrderReadyEntity> OrderReadies => Set<OrderReadyEntity>();
        public DbSet<OrderReadyEstimationEntity> OrderReadyEstimations => Set<OrderReadyEstimationEntity>();
        public DbSet<OrderReceiverEntity> OrderReceivers => Set<OrderReceiverEntity>();
        public DbSet<OrderServiceEntity> OrderServices => Set<OrderServiceEntity>();
        public DbSet<OrderStateEntity> OrderStates => Set<OrderStateEntity>();
        public DbSet<OrderSubmitEntity> OrderSubmits => Set<OrderSubmitEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderActivityEntity>().ToCollection<OrderActivityEntity>("OrderActivityCollection");

            modelBuilder.Entity<OrderCampaignEntity>().ToCollection<OrderCampaignEntity>("OrderCampaignCollection");

            modelBuilder.Entity<OrderCampaignItemEntity>().ToCollection<OrderCampaignItemEntity>("OrderCampaignItemCollection");

            modelBuilder.Entity<OrderCancelableEntity>().ToCollection<OrderCancelableEntity>("OrderCancelableCollection");

            modelBuilder.Entity<OrderHistoricalEntity>().ToCollection<OrderHistoricalEntity>("OrderHistoricalCollection");

            modelBuilder.Entity<OrderItemEntity>().ToCollection<OrderItemEntity>("OrderItemCollection");

            modelBuilder.Entity<OrderItemModifierEntity>().ToCollection<OrderItemModifierEntity>("OrderItemModifierCollection");

            modelBuilder.Entity<OrderListEntity>().ToCollection<OrderListEntity>("OrderListCollection");

            modelBuilder.Entity<OrderPriceEntity>().ToCollection<OrderPriceEntity>("OrderPriceCollection");

            modelBuilder.Entity<OrderPromotionEntity>().ToCollection<OrderPromotionEntity>("OrderPromotionCollection");

            modelBuilder.Entity<OrderReadyEntity>().ToCollection<OrderReadyEntity>("OrderReadyCollection");

            modelBuilder.Entity<OrderReadyEstimationEntity>().ToCollection<OrderReadyEstimationEntity>("OrderReadyEstimationCollection");

            modelBuilder.Entity<OrderReceiverEntity>().ToCollection<OrderReceiverEntity>("OrderReceiverCollection");

            modelBuilder.Entity<OrderServiceEntity>().ToCollection<OrderServiceEntity>("OrderServiceCollection");

            modelBuilder.Entity<OrderStateEntity>().ToCollection<OrderStateEntity>("OrderStateCollection");

            modelBuilder.Entity<OrderSubmitEntity>().ToCollection<OrderSubmitEntity>("OrderSubmitCollection");
        }
    }
}
