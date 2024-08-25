using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.GrabMart.Authorisation.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<AuthorisationActivityEntity> AuthorisationActivities { get; set; }
        DbSet<AuthorisationCredentialsEntity> AuthorisationCredentials { get; set; }
        DbSet<AuthorisationHistoricalEntity> AuthorisationHistoricals { get; set; }
        DbSet<AuthorisationServiceEntity> AuthorisationServices { get; set; }
        DbSet<AuthorisationTokenEntity> AuthorisationTokens { get; set; }
    }
}
