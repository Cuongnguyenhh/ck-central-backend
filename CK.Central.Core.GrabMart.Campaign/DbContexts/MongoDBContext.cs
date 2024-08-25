using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Campaign.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<CampaignActivityEntity> CampaignActivities => Set<CampaignActivityEntity>();
        public DbSet<CampaignHistoricalEntity> CampaignHistoricals => Set<CampaignHistoricalEntity>();
        public DbSet<CampaignListEntity> CampaignLists => Set<CampaignListEntity>();
        public DbSet<CampaignOngoingEntity> CampaignOngoings => Set<CampaignOngoingEntity>();
        public DbSet<CampaignServiceEntity> CampaignServices => Set<CampaignServiceEntity>();
        public DbSet<CampaignUpcomingEntity> CampaignUpcomings => Set<CampaignUpcomingEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CampaignActivityEntity>().ToCollection<CampaignActivityEntity>("CampaignActivityCollection");

            modelBuilder.Entity<CampaignHistoricalEntity>().ToCollection<CampaignHistoricalEntity>("CampaignHistoricalCollection");

            modelBuilder.Entity<CampaignListEntity>().ToCollection<CampaignListEntity>("CampaignListCollection");

            modelBuilder.Entity<CampaignOngoingEntity>().ToCollection<CampaignOngoingEntity>("CampaignOngoingCollection");

            modelBuilder.Entity<CampaignServiceEntity>().ToCollection<CampaignServiceEntity>("CampaignServiceCollection");

            modelBuilder.Entity<CampaignUpcomingEntity>().ToCollection<CampaignUpcomingEntity>("CampaignUpcomingCollection");
        }
    }
}
