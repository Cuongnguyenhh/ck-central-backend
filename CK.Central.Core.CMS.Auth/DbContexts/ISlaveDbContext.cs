using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Auth.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<AspNetRoleClaimEntity> AspNetRoleClaims { get; set; }
        DbSet<AspNetRoleEntity> AspNetRoles { get; set; }
        DbSet<AspNetUserClaimEntity> AspNetUserClaims { get; set; }
        DbSet<AspNetUserEntity> AspNetUsers { get; set; }
        DbSet<AspNetUserLoginEntity> AspNetUserLogins { get; set; }
        DbSet<AspNetUserRoleEntity> AspNetUserRoles { get; set; }
        DbSet<AspNetUserTokenEntity> AspNetUserTokens { get; set; }
    }
}
