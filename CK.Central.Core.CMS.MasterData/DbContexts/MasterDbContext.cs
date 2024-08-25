using CK.Central.Core.Domain.DataObjects.CMS.Configuration;
using CK.Central.Core.DbContexts;
using CK.Central.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;

namespace CK.Central.Core.CMS.MasterData.DbContexts
{
    public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContextBase(options), IMasterDbContext
    {
        public virtual DbSet<AreaEntity> Areas { get; set; }
        public virtual DbSet<CityEntity> Cities {  get; set; }
        public virtual DbSet<ConfigurationEntity> Configurations { get; set; }
        public virtual DbSet<CountryEntity> Countries { get; set; }
        public virtual DbSet<CurrencyEntity> Currencies { get; set; }
        public virtual DbSet<DefinitionEntity> Definitions { get; set; }
        public virtual DbSet<DivisionEntity> Divisions { get; set; }
        public virtual DbSet<EmailEntity> Emails { get; set; }
        public virtual DbSet<FileEntity> Files { get; set; }
        public virtual DbSet<GroupEntity> Groups { get; set; }
        public virtual DbSet<LanguageEntity> Languages { get; set; }
        public virtual DbSet<LinkEntity> Links { get; set; }
        public virtual DbSet<MessageEntity> Messages { get; set; }
        public virtual DbSet<ProvinceEntity> Provinces { get; set; }
        public virtual DbSet<ServiceEntity> Services { get; set; }
        public virtual DbSet<StatusEntity> Statuses { get; set; }
        public virtual DbSet<TokenEntity> Tokens { get; set; }
        public virtual DbSet<TypeEntity> Types { get; set; }
        public virtual DbSet<UnitEntity> Units { get; set; }
        public virtual DbSet<AuditHistoricalEntity> AuditHistoricals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<AreaEntity>();
            modelBuilder.ApplyConfiguration(new AreaConfiguration());

            modelBuilder.Entity<CityEntity>();
            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.Entity<ConfigurationEntity>();
            modelBuilder.ApplyConfiguration(new ConfigurationConfiguration());

            modelBuilder.Entity<CountryEntity>();
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            modelBuilder.Entity<CurrencyEntity>();
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());

            modelBuilder.Entity<DefinitionEntity>();
            modelBuilder.ApplyConfiguration(new DefinitionConfiguration());

            modelBuilder.Entity<DivisionEntity>();
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());

            modelBuilder.Entity<EmailEntity>();
            modelBuilder.ApplyConfiguration(new EmailConfiguration());

            modelBuilder.Entity<FileEntity>();
            modelBuilder.ApplyConfiguration(new FileConfiguration());

            modelBuilder.Entity<GroupEntity>();
            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.Entity<LanguageEntity>();
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());

            modelBuilder.Entity<LinkEntity>();
            modelBuilder.ApplyConfiguration(new LinkConfiguration());

            modelBuilder.Entity<MessageEntity>();
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            modelBuilder.Entity<ProvinceEntity>();
            modelBuilder.ApplyConfiguration(new ProvinceConfiguration());

            modelBuilder.Entity<ServiceEntity>();
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());

            modelBuilder.Entity<StatusEntity>();
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

            modelBuilder.Entity<TokenEntity>();
            modelBuilder.ApplyConfiguration(new TokenConfiguration());

            modelBuilder.Entity<TypeEntity>();
            modelBuilder.ApplyConfiguration(new TypeConfiguration());

            modelBuilder.Entity<UnitEntity>();
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            modelBuilder.Entity<AuditHistoricalEntity>();
            modelBuilder.ApplyConfiguration(new AuditHistoricalConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new DateInterceptor());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
