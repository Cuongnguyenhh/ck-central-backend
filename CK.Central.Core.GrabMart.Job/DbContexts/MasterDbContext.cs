using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Job.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        //public DbSet<CampaignEntity> Campaigns => Set<CampaignEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.Entity<GroupEntity>();
            //modelBuilder.ApplyConfiguration(new GroupConfiguration());

            //modelBuilder.Entity<CampaignEntity>();
            //modelBuilder.Entity<CategoryEntity>();
            //modelBuilder.Entity<CityEntity>();
            //modelBuilder.Entity<CurrencyEntity>();
            //modelBuilder.Entity<DefinitionEntity>();
            //modelBuilder.Entity<DepartmentEntity>();
            //modelBuilder.Entity<DisclaimerEntity>();
            //modelBuilder.Entity<ItemEntity>();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
