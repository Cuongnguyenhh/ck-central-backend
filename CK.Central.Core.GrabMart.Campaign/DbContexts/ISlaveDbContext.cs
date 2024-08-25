using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.GrabMart.Campaign.DbContexts
{
    public interface ISlaveDbContext : IDbContextBase
    {
        DbSet<CampaignActivityEntity> CampaignActivities { get; set; }
        DbSet<CampaignHistoricalEntity> CampaignHistoricals { get; set; }
        DbSet<CampaignListEntity> CampaignLists { get; set; }
        DbSet<CampaignOngoingEntity> CampaignOngoings { get; set; }
        DbSet<CampaignServiceEntity> CampaignServices { get; set; }
        DbSet<CampaignUpcomingEntity> CampaignUpcomings { get; set; }
    }
}
