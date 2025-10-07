using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs;

public class StockMovementConfig : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("StockMovement");

        builder.HasKey(sm => sm.Id);
        builder.Property(sm => sm.Id).ValueGeneratedOnAdd();

        builder.Property(sm => sm.MovementType)
               .HasColumnName("Type_")
               .IsRequired()
               .HasConversion<string>();

        builder.Property(sm => sm.Quantity);

        builder.HasOne(sm => sm.Product).WithMany(p => p.Movements).HasForeignKey(sm => sm.ProductId);
    }
}