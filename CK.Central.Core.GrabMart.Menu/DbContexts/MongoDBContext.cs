using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Menu.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<MenuActivityEntity> MenuActivities => Set<MenuActivityEntity>();
        public DbSet<MenuCategoriesEntity> MenuCategories => Set<MenuCategoriesEntity>();
        public DbSet<MenuHistoricalEntity> MenuHistoricals => Set<MenuHistoricalEntity>();
        public DbSet<MenuMartEntity> MenuMarts => Set<MenuMartEntity>();
        public DbSet<MenuNotificationEntity> MenuNotifications => Set<MenuNotificationEntity>();
        public DbSet<MenuRecordEntity> MenuRecords => Set<MenuRecordEntity>();
        public DbSet<MenuSellingTimeEntity> MenuSellingTimes => Set<MenuSellingTimeEntity>();
        public DbSet<MenuServiceEntity> MenuServices => Set<MenuServiceEntity>();
        public DbSet<MenuSyncWebhookEntity> MenuSyncWebhooks => Set<MenuSyncWebhookEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MenuActivityEntity>().ToCollection<MenuActivityEntity>("MenuActivityCollection");
            modelBuilder.Entity<MenuCategoriesEntity>().ToCollection<MenuCategoriesEntity>("MenuCategoriesCollection");
            modelBuilder.Entity<MenuHistoricalEntity>().ToCollection<MenuHistoricalEntity>("MenuHistoricalCollection");
            modelBuilder.Entity<MenuMartEntity>().ToCollection<MenuMartEntity>("MenuMartCollection");
            modelBuilder.Entity<MenuRecordEntity>().ToCollection<MenuRecordEntity>("MenuRecordCollection");
            modelBuilder.Entity<MenuSellingTimeEntity>().ToCollection<MenuSellingTimeEntity>("MenuSellingTimeCollection");
            modelBuilder.Entity<MenuServiceEntity>().ToCollection<MenuServiceEntity>("MenuServiceCollection");
            modelBuilder.Entity<MenuSyncWebhookEntity>().ToCollection<MenuSyncWebhookEntity>("MenuSyncWebhookCollection");
        }
    }
}
