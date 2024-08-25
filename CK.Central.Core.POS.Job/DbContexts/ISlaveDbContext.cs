using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.Job.DbContexts
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
