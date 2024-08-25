using CK.Central.Core.DbContexts;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;

namespace CK.Central.Core.CMS.MasterData.DbContexts
{
    public interface IMasterDbContext : IDbContextBase
    {
        DbSet<AreaEntity> Areas { get; set; }
        DbSet<CityEntity> Cities { get; set; }
        DbSet<ConfigurationEntity> Configurations { get; set; }
        DbSet<CountryEntity> Countries { get; set; }
        DbSet<CurrencyEntity> Currencies { get; set; }
        DbSet<DefinitionEntity> Definitions { get; set; }
        DbSet<DivisionEntity> Divisions { get; set; }
        DbSet<EmailEntity> Emails { get; set; }
        DbSet<FileEntity> Files { get; set; }
        DbSet<GroupEntity> Groups { get; set; }
        DbSet<LanguageEntity> Languages { get; set; }
        DbSet<LinkEntity> Links { get; set; }
        DbSet<MessageEntity> Messages { get; set; }
        DbSet<ProvinceEntity> Provinces { get; set; }
        DbSet<ServiceEntity> Services { get; set; }
        DbSet<StatusEntity> Statuses { get; set; }
        DbSet<TokenEntity> Tokens { get; set; }
        DbSet<TypeEntity> Types { get; set; }
        DbSet<UnitEntity> Units { get; set; }
        DbSet<AuditHistoricalEntity> AuditHistoricals { get; set; }
    }
}
