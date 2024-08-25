using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.GrabMart.Store.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<StoreActivityEntity> StoreActivities { get; set; }
        DbSet<StoreDeliveryHoursEntity> StoreDeliveryHours { get; set; }
        DbSet<StoreHistoricalEntity> StoreHistoricals { get; set; }
        DbSet<StoreHoursEntity> StoreHours { get; set; }
        DbSet<StorePauseEntity> StorePauses { get; set; }
        DbSet<StoreServiceEntity> StoreServices { get; set; }
        DbSet<StoreSpecialHoursEntity> StoreSpecialHours { get; set; }
        DbSet<StoreStatusEntity> StoreStatuses { get; set; }
    }
}
