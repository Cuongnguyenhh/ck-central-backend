using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.HealthCheck.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<HealthcheckActivityEntity> HealthcheckActivities { get; set; }
        DbSet<HealthcheckHistoricalEntity> HealthcheckHistoricals { get; set; }
        DbSet<HealthcheckIncidentEntity> GetHealthcheckIncidents { get; set; }
        DbSet<HealthcheckPipelineEntity> HealthcheckPipelines { get; set; }
    }
}
