using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.DbContexts
{
    public class SlaveDbContext(DbContextOptions<SlaveDbContext> options) : DbContextBase(options), ISlaveDbContext
    {
        public virtual DbSet<AspNetRoleClaimEntity> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoleEntity> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaimEntity> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserEntity> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserLoginEntity> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoleEntity> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokenEntity> AspNetUserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<AspNetRoleClaimEntity>();
            modelBuilder.Entity<AspNetRoleEntity>();
            modelBuilder.Entity<AspNetUserClaimEntity>();
            modelBuilder.Entity<AspNetUserEntity>();
            modelBuilder.Entity<AspNetUserLoginEntity>();
            modelBuilder.Entity<AspNetUserRoleEntity>();
            modelBuilder.Entity<AspNetUserTokenEntity>();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfiguration Configuration = builder.Build();

            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("SlavePgsqlDbConnection"), builder =>
            {
                builder.MigrationsAssembly("CK.Central.API.CMS.Auth");
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}
