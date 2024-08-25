using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.GrabMart.Order.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<OrderActivityEntity> OrderActivities { get; set; }
        DbSet<OrderCampaignEntity> OrderCampaigns { get; set; }
        DbSet<OrderCampaignItemEntity> OrderCampaignItems { get; set; }
        DbSet<OrderCancelableEntity> OrderCancelables { get; set; }
        DbSet<OrderHistoricalEntity> OrderHistoricals { get; set; }
        DbSet<OrderItemEntity> OrderItems { get; set; }
        DbSet<OrderItemModifierEntity> OrderItemModifiers { get; set; }
        DbSet<OrderListEntity> OrderLists { get; set; }
        DbSet<OrderPriceEntity> OrderPrices { get; set; }
        DbSet<OrderPromotionEntity> OrderPromotions { get; set; }
        DbSet<OrderReadyEntity> OrderReadies { get; set; }
        DbSet<OrderReadyEstimationEntity> OrderReadyEstimations { get; set; }
        DbSet<OrderReceiverEntity> OrderReceivers { get; set; }
        DbSet<OrderServiceEntity> OrderServices { get; set; }
        DbSet<OrderStateEntity> OrderStates { get; set; }
        DbSet<OrderSubmitEntity> OrderSubmits { get; set; }
    }
}
