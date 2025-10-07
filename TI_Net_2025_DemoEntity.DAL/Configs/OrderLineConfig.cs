using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.ToTable(ol => ol.HasCheckConstraint("CK_OrderLine__Quantity","Quantity >= 0"));
            builder.HasKey(ol => ol.Id);

            builder.Property(ol => ol.Id).ValueGeneratedOnAdd();
            builder.Property(ol => ol.Quantity).IsRequired();

            builder.HasOne(ol => ol.Product)
                .WithMany(p => p.Lines)
                .HasForeignKey(ol => ol.ProductId);

            builder.HasOne(ol => ol.Order)
                .WithMany(o => o.Lines)
                .HasForeignKey(ol => ol.OrderId);
        }
    }
}
