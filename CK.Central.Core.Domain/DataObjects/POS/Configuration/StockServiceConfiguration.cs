using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.Domain.DataObjects.POS.Configuration
{
    public class StockServiceConfiguration : IEntityTypeConfiguration<StockServiceEntity>
    {
        public void Configure(EntityTypeBuilder<StockServiceEntity> builder)
        {
            builder.ToTable("stock_service");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
