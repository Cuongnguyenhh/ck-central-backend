using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CK.Central.Core.GrabMart.Authorisation.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<AuthorisationActivityEntity> AuthorisationActivities { get; set; }
        public virtual DbSet<AuthorisationCredentialsEntity> AuthorisationCredentials { get; set; }
        public virtual DbSet<AuthorisationHistoricalEntity> AuthorisationHistoricals { get; set; }
        public virtual DbSet<AuthorisationServiceEntity> AuthorisationServices { get; set; }
        public virtual DbSet<AuthorisationTokenEntity> AuthorisationTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<AuthorisationActivityEntity>();
            modelBuilder.ApplyConfiguration(new AuthorisationActivityConfiguration());

            modelBuilder.Entity<AuthorisationCredentialsEntity>();
            modelBuilder.ApplyConfiguration(new AuthorisationCredentialsConfiguration());

            modelBuilder.Entity<AuthorisationHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new AuthorisationHistoricalConfiguration());

            modelBuilder.Entity<AuthorisationServiceEntity>();
            modelBuilder.ApplyConfiguration(new AuthorisationServiceConfiguration());

            modelBuilder.Entity<AuthorisationTokenEntity>();
            modelBuilder.ApplyConfiguration(new AuthorisationTokenConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
