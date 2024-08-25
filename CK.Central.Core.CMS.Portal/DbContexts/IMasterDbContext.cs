using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Portal.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<CampaignEntity> Campaigns { get; set; }
        DbSet<CampaignItemEntity> CampaignItems { get; set; }
        DbSet<CampaignServiceEntity> CampaignServices { get; set; }
        DbSet<CategoryEntity> Categories { get; set; }
        DbSet<CustomerEntity> Customers { get; set; }
        DbSet<DepartmentEntity> Departments { get; set; }
        DbSet<DisclaimerEntity> Disclaimers { get; set; }
        DbSet<ItemDetailEntity> ItemDetails { get; set; }
        DbSet<ItemDisclaimerEntity> ItemDisclaimers { get; set; }
        DbSet<ItemEntity> Items { get; set; }
        DbSet<MenuEntity> Menus { get; set; }
        DbSet<MenuItemEntity> MenuItems { get; set; }
        DbSet<MenuServiceEntity> MenuServices { get; set; }
        DbSet<MenuTemplateEntity> MenuTemplates { get; set; }
        DbSet<ReportEntity> Reports { get; set; }
        DbSet<ReportTemplateEntity> ReportTemplates { get; set; }
        DbSet<OrderEntity> Orders { get; set; }
        DbSet<OrderItemEntity> OrderItems { get; set; }
        DbSet<OrderStateEntity> OrderStates { get; set; }
        DbSet<OrderServiceEntity> OrderServices { get; set; }
        DbSet<StoreEntity> Stores { get; set; }
        DbSet<StoreServiceEntity> StoreServices { get; set; }

        DbSet<AuditHistoricalEntity> AuditHistoricals { get; set; }
    }
}
