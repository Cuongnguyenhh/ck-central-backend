using CK.Central.Core.Domain.DataObjects.CMS.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<StoreEntity>
    {
        public void Configure(EntityTypeBuilder<StoreEntity> builder)
        {
            builder.ToTable("store");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
