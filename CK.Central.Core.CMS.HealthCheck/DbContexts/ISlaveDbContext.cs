using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.HealthCheck.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<HealthcheckActivityEntity> HealthcheckActivities { get; set; }
        DbSet<HealthcheckHistoricalEntity> HealthcheckHistoricals { get; set; }
        DbSet<HealthcheckIncidentEntity> GetHealthcheckIncidents { get; set; }
        DbSet<HealthcheckPipelineEntity> HealthcheckPipelines { get; set; }
    }
}
