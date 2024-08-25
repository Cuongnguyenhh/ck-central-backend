using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.GrabMart.Configuration;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.GrabMart.Authorisation.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<AuthorisationActivityEntity> AuthorisationActivities => Set<AuthorisationActivityEntity>();
        public DbSet<AuthorisationCredentialsEntity> AuthorisationCredentials => Set<AuthorisationCredentialsEntity>();
        public DbSet<AuthorisationHistoricalEntity> AuthorisationHistoricals => Set<AuthorisationHistoricalEntity>();
        public DbSet<AuthorisationServiceEntity> AuthorisationServices => Set<AuthorisationServiceEntity>();
        public DbSet<AuthorisationTokenEntity> AuthorisationTokens => Set<AuthorisationTokenEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorisationActivityEntity>().ToCollection<AuthorisationActivityEntity>("AuthorisationActivityCollection");

            modelBuilder.Entity<AuthorisationCredentialsEntity>().ToCollection<AuthorisationCredentialsEntity>("AuthorisationCredentialsCollection");

            modelBuilder.Entity<AuthorisationHistoricalEntity>().ToCollection<AuthorisationHistoricalEntity>("AuthorisationHistoricalCollection");

            modelBuilder.Entity<AuthorisationServiceEntity>().ToCollection<AuthorisationServiceEntity>("AuthorisationServiceCollection");

            modelBuilder.Entity<AuthorisationTokenEntity>().ToCollection<AuthorisationTokenEntity>("AuthorisationTokenCollection");

        }
    }
}
