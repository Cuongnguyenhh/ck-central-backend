using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using CK.Central.Core.Domain.DataObjects.CMS.Configuration;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;

namespace CK.Central.Core.CMS.Portal.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<CampaignEntity> Campaigns => Set<CampaignEntity>();
        public DbSet<CampaignItemEntity> CampaignItems => Set<CampaignItemEntity>();
        public DbSet<CampaignServiceEntity> CampaignServices => Set<CampaignServiceEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<DepartmentEntity> Departments => Set<DepartmentEntity>();
        public DbSet<DisclaimerEntity> Disclaimers => Set<DisclaimerEntity>();
        public DbSet<ItemDetailEntity> ItemDetails => Set<ItemDetailEntity>();
        public DbSet<ItemDisclaimerEntity> ItemDisclaimers => Set<ItemDisclaimerEntity>();
        public DbSet<ItemEntity> Items => Set<ItemEntity>();
        public DbSet<MenuEntity> Menus => Set<MenuEntity>();
        public DbSet<MenuItemEntity> MenuItems => Set<MenuItemEntity>();
        public DbSet<MenuServiceEntity> MenuServices => Set<MenuServiceEntity>();
        public DbSet<MenuTemplateEntity> MenuTemplates => Set<MenuTemplateEntity>();
        public DbSet<ReportEntity> Reports => Set<ReportEntity>();
        public DbSet<ReportTemplateEntity> ReportTemplates => Set<ReportTemplateEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
        public DbSet<OrderStateEntity> OrderStates => Set<OrderStateEntity>();
        public DbSet<OrderServiceEntity> OrderServices => Set<OrderServiceEntity>();
        public DbSet<StoreEntity> Stores => Set<StoreEntity>();
        public DbSet<StoreServiceEntity> StoreServices => Set<StoreServiceEntity>();
        public DbSet<AuditHistoricalEntity> AuditHistoricals => Set<AuditHistoricalEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CampaignEntity>().ToCollection<CampaignEntity>("CampaignCollection");

            modelBuilder.Entity<CampaignItemEntity>().ToCollection<CampaignItemEntity>("CampaignItemCollection");

            modelBuilder.Entity<CampaignServiceEntity>().ToCollection<CampaignServiceEntity>("CampaignServiceCollection");

            modelBuilder.Entity<CategoryEntity>().ToCollection<CategoryEntity>("CategoryCollection");

            modelBuilder.Entity<CustomerEntity>().ToCollection<CustomerEntity>("CustomerCollection");

            modelBuilder.Entity<DepartmentEntity>().ToCollection<DepartmentEntity>("DepartmentCollection");

            modelBuilder.Entity<DisclaimerEntity>().ToCollection<DisclaimerEntity>("DisclaimerCollection");

            modelBuilder.Entity<ItemEntity>().ToCollection<ItemEntity>("ItemCollection");

            modelBuilder.Entity<ItemDisclaimerEntity>().ToCollection<ItemDisclaimerEntity>("ItemDisclaimerCollection");

            modelBuilder.Entity<ItemDetailEntity>().ToCollection<ItemDetailEntity>("ItemDetailCollection");

            modelBuilder.Entity<MenuEntity>().ToCollection<MenuEntity>("MenuCollection");

            modelBuilder.Entity<MenuItemEntity>().ToCollection<MenuItemEntity>("MenuItemCollection");

            modelBuilder.Entity<MenuServiceEntity>().ToCollection<MenuServiceEntity>("MenuServiceCollection");

            modelBuilder.Entity<MenuTemplateEntity>().ToCollection<MenuTemplateEntity>("MenuTemplateCollection");

            modelBuilder.Entity<ReportEntity>().ToCollection<ReportEntity>("ReportCollection");

            modelBuilder.Entity<ReportTemplateEntity>().ToCollection<ReportTemplateEntity>("ReportTemplateCollection");
            
            modelBuilder.Entity<OrderEntity>().ToCollection<OrderEntity>("OrderCollection");

            modelBuilder.Entity<OrderItemEntity>().ToCollection<OrderItemEntity>("OrderItemCollection");

            modelBuilder.Entity<OrderStateEntity>().ToCollection<OrderStateEntity>("OrderStateCollection");

            modelBuilder.Entity<OrderServiceEntity>().ToCollection<OrderServiceEntity>("OrderServiceCollection");

            modelBuilder.Entity<StoreEntity>().ToCollection<StoreEntity>("StoreCollection");

            modelBuilder.Entity<StoreServiceEntity>().ToCollection<StoreServiceEntity>("StoreServiceCollection");

            modelBuilder.Entity<AuditHistoricalEntity>().ToCollection<AuditHistoricalEntity>("AuditHistoricalCollection");
        }
    }
}
