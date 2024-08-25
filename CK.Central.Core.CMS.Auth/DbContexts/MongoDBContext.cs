using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Auth.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<AspNetRoleClaimEntity> AspNetRoleClaims => Set<AspNetRoleClaimEntity>();
        public virtual DbSet<AspNetRoleEntity> AspNetRoles => Set<AspNetRoleEntity>();
        public virtual DbSet<AspNetUserClaimEntity> AspNetUserClaims => Set<AspNetUserClaimEntity>();
        public virtual DbSet<AspNetUserEntity> AspNetUsers => Set<AspNetUserEntity>();
        public virtual DbSet<AspNetUserLoginEntity> AspNetUserLogins => Set<AspNetUserLoginEntity>();
        public virtual DbSet<AspNetUserRoleEntity> AspNetUserRoles => Set<AspNetUserRoleEntity>();
        public virtual DbSet<AspNetUserTokenEntity> AspNetUserTokens => Set<AspNetUserTokenEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetRoleClaimEntity>().ToCollection<AspNetRoleClaimEntity>("AspNetRoleClaimCollection");
            modelBuilder.Entity<AspNetRoleEntity>().ToCollection<AspNetRoleEntity>("AspNetRoleCollection");
            modelBuilder.Entity<AspNetUserClaimEntity>().ToCollection<AspNetUserClaimEntity>("AspNetUserClaimCollection");
            modelBuilder.Entity<AspNetUserEntity>().ToCollection<AspNetUserEntity>("AspNetUserCollection");
            modelBuilder.Entity<AspNetUserLoginEntity>().ToCollection<AspNetUserLoginEntity>("AspNetUserLoginCollection");
            modelBuilder.Entity<AspNetUserRoleEntity>().ToCollection<AspNetUserRoleEntity>("AspNetUserRoleCollection");
            modelBuilder.Entity<AspNetUserTokenEntity>().ToCollection<AspNetUserTokenEntity>("AspNetUserTokenCollection");
        }
    }
}
