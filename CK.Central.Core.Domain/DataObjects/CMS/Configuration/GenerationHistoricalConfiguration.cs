using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Configuration
{
    public class GenerationHistoricalConfiguration : IEntityTypeConfiguration<GenerationHistoricalEntity>
    {
        public void Configure(EntityTypeBuilder<GenerationHistoricalEntity> builder)
        {
            builder.ToTable("generation_historical");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
