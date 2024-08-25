using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.Generate.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<GenerationActivityEntity> GenerationActivities { get; set; }
        DbSet<GenerationHistoricalEntity> GenerationHistoricals { get; set; }
        DbSet<GenerationPipelineEntity> GenerationPipelines { get; set; }
    }
}
