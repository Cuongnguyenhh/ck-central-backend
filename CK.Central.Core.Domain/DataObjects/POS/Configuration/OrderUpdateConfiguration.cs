using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CK.Central.Core.Domain.DataObjects.POS.Entity;

namespace CK.Central.Core.Domain.DataObjects.POS.Configuration
{
    public class OrderUpdateConfiguration : IEntityTypeConfiguration<OrderUpdateEntity>
    {
        public void Configure(EntityTypeBuilder<OrderUpdateEntity> builder)
        {
            builder.ToTable("order_update");
            builder.HasKey(o => o.PK_UUID);
            builder.Property(o => o.PK_UUID).ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).IsRequired();
            builder.Property(o => o.IsDeleted).IsRequired();
            builder.Property(o => o.CreatedBy).IsRequired();
            builder.Property(o => o.CreatedDatetime).IsRequired();
        }
    }
}
