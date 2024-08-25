using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.GrabMart.Menu.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<MenuActivityEntity> MenuActivities { get; set; }
        DbSet<MenuCategoriesEntity> MenuCategories { get; set; }
        DbSet<MenuHistoricalEntity> MenuHistoricals { get; set; }
        DbSet<MenuMartEntity> MenuMarts { get; set; }
        DbSet<MenuNotificationEntity> MenuNotifications { get; set; }
        DbSet<MenuRecordEntity> MenuRecords { get; set; }
        DbSet<MenuSellingTimeEntity> MenuSellingTimes { get; set; }
        DbSet<MenuServiceEntity> MenuServices { get; set; }
        DbSet<MenuSyncWebhookEntity> MenuSyncWebhooks { get; set; }
    }
}
