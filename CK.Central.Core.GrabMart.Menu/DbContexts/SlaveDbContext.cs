using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Menu.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<MenuActivityEntity> MenuActivities { get; set; }
        public virtual DbSet<MenuCategoriesEntity> MenuCategories { get; set; }
        public virtual DbSet<MenuHistoricalEntity> MenuHistoricals { get; set; }
        public virtual DbSet<MenuMartEntity> MenuMarts { get; set; }
        public virtual DbSet<MenuNotificationEntity> MenuNotifications { get; set; }
        public virtual DbSet<MenuRecordEntity> MenuRecords { get; set; }
        public virtual DbSet<MenuSellingTimeEntity> MenuSellingTimes { get; set; }
        public virtual DbSet<MenuServiceEntity> MenuServices { get; set; }
        public virtual DbSet<MenuSyncWebhookEntity> MenuSyncWebhooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<MenuActivityEntity>();
            modelBuilder.ApplyConfiguration(new MenuActivityConfiguration());

            modelBuilder.Entity<MenuCategoriesEntity>();
            modelBuilder.ApplyConfiguration(new MenuCategoriesConfiguration());

            modelBuilder.Entity<MenuHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new MenuHistoricalConfiguration());

            modelBuilder.Entity<MenuMartEntity>();
            modelBuilder.ApplyConfiguration(new MenuMartConfiguration());

            modelBuilder.Entity<MenuNotificationEntity>();
            modelBuilder.ApplyConfiguration(new MenuNotificationConfiguration());

            modelBuilder.Entity<MenuRecordEntity>();
            modelBuilder.ApplyConfiguration(new MenuRecordConfiguration());

            modelBuilder.Entity<MenuSellingTimeEntity>();
            modelBuilder.ApplyConfiguration(new MenuSellingTimeConfiguration());

            modelBuilder.Entity<MenuServiceEntity>();
            modelBuilder.ApplyConfiguration(new MenuServiceConfiguration());

            modelBuilder.Entity<MenuSyncWebhookEntity>();
            modelBuilder.ApplyConfiguration(new MenuSyncWebhookConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
