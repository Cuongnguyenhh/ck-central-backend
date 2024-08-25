using CK.Central.Core.Domain.DataObjects.CMS.Configuration;
using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.MasterData.DbContexts
{
    public class MongoDBContext : DbContext
    {
        public MongoDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        public DbSet<AreaEntity> Areas => Set<AreaEntity>();
        public DbSet<CityEntity> Cities => Set<CityEntity>();
        public DbSet<ConfigurationEntity> Configurations => Set<ConfigurationEntity>();
        public DbSet<CountryEntity> Countries => Set<CountryEntity>();
        public DbSet<CurrencyEntity> Currencies => Set<CurrencyEntity>();
        public DbSet<DefinitionEntity> Definitions => Set<DefinitionEntity>();
        public DbSet<DivisionEntity> Divisions => Set<DivisionEntity>();
        public DbSet<EmailEntity> Emails => Set<EmailEntity>();
        public DbSet<FileEntity> Files => Set<FileEntity>();
        public DbSet<GroupEntity> Groups => Set<GroupEntity>();
        public DbSet<LanguageEntity> Languages => Set<LanguageEntity>();
        public DbSet<LinkEntity> Links => Set<LinkEntity>();
        public DbSet<MessageEntity> Messages => Set<MessageEntity>();
        public DbSet<ProvinceEntity> Provinces => Set<ProvinceEntity>();
        public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
        public DbSet<StatusEntity> Statuses => Set<StatusEntity>();
        public DbSet<TokenEntity> Tokens => Set<TokenEntity>();
        public DbSet<TypeEntity> Types => Set<TypeEntity>();
        public DbSet<UnitEntity> Units => Set<UnitEntity>();
        public DbSet<AuditHistoricalEntity> AuditHistoricals => Set<AuditHistoricalEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AreaEntity>().ToCollection<AreaEntity>("AreaCollection");

            modelBuilder.Entity<CityEntity>().ToCollection<CityEntity>("CityCollection");

            modelBuilder.Entity<ConfigurationEntity>().ToCollection<ConfigurationEntity>("ConfigurationCollection");

            modelBuilder.Entity<CountryEntity>().ToCollection<CountryEntity>("CountryCollection");

            modelBuilder.Entity<CurrencyEntity>().ToCollection<CurrencyEntity>("CurrencyCollection");

            modelBuilder.Entity<DefinitionEntity>().ToCollection<DefinitionEntity>("DefinitionCollection");

            modelBuilder.Entity<DivisionEntity>().ToCollection<DivisionEntity>("DivisionCollection");

            modelBuilder.Entity<EmailEntity>().ToCollection<EmailEntity>("EmailCollection");

            modelBuilder.Entity<FileEntity>().ToCollection<FileEntity>("FilePathCollection");

            modelBuilder.Entity<GroupEntity>().ToCollection<GroupEntity>("GroupCollection");

            modelBuilder.Entity<LanguageEntity>().ToCollection<LanguageEntity>("LanguageCollection");

            modelBuilder.Entity<LinkEntity>().ToCollection<LinkEntity>("LinkCollection");

            modelBuilder.Entity<MessageEntity>().ToCollection<MessageEntity>("MessageCollection");

            modelBuilder.Entity<ProvinceEntity>().ToCollection<ProvinceEntity>("ProvinceCollection");

            modelBuilder.Entity<ServiceEntity>().ToCollection<ServiceEntity>("ServiceCollection");

            modelBuilder.Entity<StatusEntity>().ToCollection<StatusEntity>("StatusCollection");

            modelBuilder.Entity<TokenEntity>().ToCollection<TokenEntity>("TokenCollection");

            modelBuilder.Entity<TypeEntity>().ToCollection<TypeEntity>("TypeCollection");

            modelBuilder.Entity<UnitEntity>().ToCollection<UnitEntity>("UnitCollection");

            modelBuilder.Entity<AuditHistoricalEntity>().ToCollection<AuditHistoricalEntity>("AuditHistoricalCollection");
        }
    }
}
