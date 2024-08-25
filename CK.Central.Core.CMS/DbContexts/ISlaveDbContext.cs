using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<GeneralActivityEntity> GeneralActivities { get; set; }
        DbSet<GeneralCommandEntity> GeneralCommands { get; set; }
        DbSet<GeneralHistoricalEntity> GeneralHistoricals { get; set; }
        DbSet<GeneralPipelineEntity> GeneralPipelines { get; set; }
    }
}
