using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Campaign.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        public virtual DbSet<CampaignActivityEntity> CampaignActivities { get; set; }
        public virtual DbSet<CampaignHistoricalEntity> CampaignHistoricals { get; set; }
        public virtual DbSet<CampaignListEntity> CampaignLists { get; set; }
        public virtual DbSet<CampaignOngoingEntity> CampaignOngoings { get; set; }
        public virtual DbSet<CampaignServiceEntity> CampaignServices { get; set; }
        public virtual DbSet<CampaignUpcomingEntity> CampaignUpcomings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<CampaignActivityEntity>();
            modelBuilder.ApplyConfiguration(new CampaignActivityConfiguration());

            modelBuilder.Entity<CampaignHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new CampaignHistoricalConfiguration());

            modelBuilder.Entity<CampaignListEntity>();
            modelBuilder.ApplyConfiguration(new CampaignListConfiguration());

            modelBuilder.Entity<CampaignOngoingEntity>();
            modelBuilder.ApplyConfiguration(new CampaignOngoingConfiguration());

            modelBuilder.Entity<CampaignServiceEntity>();
            modelBuilder.ApplyConfiguration(new CampaignServiceConfiguration());

            modelBuilder.Entity<CampaignUpcomingEntity>();
            modelBuilder.ApplyConfiguration(new CampaignUpcomingConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
