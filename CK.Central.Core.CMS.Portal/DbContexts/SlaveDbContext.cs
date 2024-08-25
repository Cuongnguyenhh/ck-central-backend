using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.CMS.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.Extensions.Configuration;

namespace CK.Central.Core.CMS.Portal.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<CampaignEntity> Campaigns { get; set; }
        public virtual DbSet<CampaignItemEntity> CampaignItems { get; set; }
        public virtual DbSet<CampaignServiceEntity> CampaignServices { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<CustomerEntity> Customers { get; set; }
        public virtual DbSet<DepartmentEntity> Departments { get; set; }
        public virtual DbSet<DisclaimerEntity> Disclaimers { get; set; }
        public virtual DbSet<ItemDetailEntity> ItemDetails { get; set; }
        public virtual DbSet<ItemDisclaimerEntity> ItemDisclaimers { get; set; }
        public virtual DbSet<ItemEntity> Items { get; set; }
        public virtual DbSet<MenuEntity> Menus { get; set; }
        public virtual DbSet<MenuItemEntity> MenuItems { get; set; }
        public virtual DbSet<MenuServiceEntity> MenuServices { get; set; }
        public virtual DbSet<MenuTemplateEntity> MenuTemplates { get; set; }
        public virtual DbSet<ReportEntity> Reports { get; set; }
        public virtual DbSet<ReportTemplateEntity> ReportTemplates { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<OrderStateEntity> OrderStates { get; set; }
        public virtual DbSet<OrderServiceEntity> OrderServices { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
        public virtual DbSet<StoreEntity> Stores { get; set; }
        public virtual DbSet<StoreServiceEntity> StoreServices { get; set; }
        public virtual DbSet<AuditHistoricalEntity> AuditHistoricals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<CampaignEntity>();
            modelBuilder.ApplyConfiguration(new CampaignConfiguration());

            modelBuilder.Entity<CampaignItemEntity>();
            modelBuilder.ApplyConfiguration(new CampaignItemConfiguration());

            modelBuilder.Entity<CampaignServiceEntity>();
            modelBuilder.ApplyConfiguration(new CampaignServiceConfiguration());

            modelBuilder.Entity<CategoryEntity>();
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<CustomerEntity>();
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());

            modelBuilder.Entity<DepartmentEntity>();
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.Entity<DisclaimerEntity>();
            modelBuilder.ApplyConfiguration(new DisclaimerConfiguration());

            modelBuilder.Entity<ItemEntity>();
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            modelBuilder.Entity<ItemDisclaimerEntity>();
            modelBuilder.ApplyConfiguration(new ItemDisclaimerConfiguration());

            modelBuilder.Entity<ItemDetailEntity>();
            modelBuilder.ApplyConfiguration(new ItemDetailConfiguration());

            modelBuilder.Entity<MenuEntity>();
            modelBuilder.ApplyConfiguration(new MenuConfiguration());

            modelBuilder.Entity<MenuItemEntity>();
            modelBuilder.ApplyConfiguration(new MenuItemConfiguration());

            modelBuilder.Entity<MenuServiceEntity>();
            modelBuilder.ApplyConfiguration(new MenuServiceConfiguration());

            modelBuilder.Entity<MenuTemplateEntity>();
            modelBuilder.ApplyConfiguration(new MenuTemplateConfiguration());

            modelBuilder.Entity<ReportEntity>();
            modelBuilder.ApplyConfiguration(new ReportConfiguration());

            modelBuilder.Entity<ReportTemplateEntity>();
            modelBuilder.ApplyConfiguration(new ReportTemplateConfiguration());

            modelBuilder.Entity<OrderEntity>();
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<OrderItemEntity>();
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());

            modelBuilder.Entity<OrderStateEntity>();
            modelBuilder.ApplyConfiguration(new OrderStateConfiguration());

            modelBuilder.Entity<OrderServiceEntity>();
            modelBuilder.ApplyConfiguration(new OrderServiceConfiguration());

            modelBuilder.Entity<StoreEntity>();
            modelBuilder.ApplyConfiguration(new StoreConfiguration());

            modelBuilder.Entity<StoreServiceEntity>();
            modelBuilder.ApplyConfiguration(new StoreServiceConfiguration());

            modelBuilder.Entity<AuditHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new AuditHistoricalConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());

            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
            .AddJsonFile("appsettings.json", false).Build();

            optionsBuilder.UseNpgsql(builder.GetConnectionString("SlavePgsqlDbConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
