using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.Job.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<JobActivityEntity> JobActivities { get; set; }
        DbSet<JobHistoricalEntity> JobHistoricals { get; set; }
        DbSet<JobPipelineEntity> JobPipelines { get; set; }
        DbSet<TaskActivityEntity> TaskActivities { get; set; }
        DbSet<TaskHandledEntity> TaskHandleds { get; set; }
        DbSet<TaskHistoricalEntity> TaskHistoricals { get; set; }
        DbSet<TaskPipelineEntity> TaskPipelines { get; set; }
    }
}
