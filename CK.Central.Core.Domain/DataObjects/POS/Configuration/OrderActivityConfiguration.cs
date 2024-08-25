using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.Domain.DataObjects.POS.Configuration
{
    public class OrderActivityConfiguration : IEntityTypeConfiguration<OrderActivityEntity>
    {
        public void Configure(EntityTypeBuilder<OrderActivityEntity> builder)
        {
            builder.ToTable("order_activity");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
