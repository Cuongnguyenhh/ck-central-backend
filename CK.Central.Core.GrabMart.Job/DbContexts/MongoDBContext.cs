using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKCK.Central.Core.GrabMart.Job.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<CampaignServiceEntity> Campaigns => Set<CampaignServiceEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<CampaignServiceEntity>().ToCollection<CampaignServiceEntity>("CampaignServiceCollection");
        }
    }
}
