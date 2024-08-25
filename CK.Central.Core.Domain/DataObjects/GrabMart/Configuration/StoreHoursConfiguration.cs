using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.GrabMart.Entity;

namespace CK.Central.Core.Domain.DataObjects.GrabMart.Configuration
{
    public class StoreHoursConfiguration : IEntityTypeConfiguration<StoreHoursEntity>
    {
        public void Configure(EntityTypeBuilder<StoreHoursEntity> builder)
        {
            builder.ToTable("store_hours");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
