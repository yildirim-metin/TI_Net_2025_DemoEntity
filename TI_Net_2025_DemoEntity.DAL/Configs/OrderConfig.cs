using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .ToTable("Order_", o => o.HasCheckConstraint("CK_Order__Discount", "Discount >= 0"))
                .HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Date).IsRequired().HasColumnType("datetime2").HasColumnName("Datte");
            builder.Property(o => o.Discount).IsRequired().HasDefaultValue(0);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder.HasMany(o => o.Lines)
                .WithOne(ol => ol.Order);
        }
    }
}
