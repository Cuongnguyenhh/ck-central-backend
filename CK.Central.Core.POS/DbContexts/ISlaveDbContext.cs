using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.POS.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<GeneralActivityEntity> GeneralActivities { get; set; }
        DbSet<GeneralCommandEntity> GeneralCommands { get; set; }
        DbSet<GeneralHistoricalEntity> GeneralHistoricals { get; set; }
        DbSet<GeneralPipelineEntity> GeneralPipelines { get; set; }
    }
}
