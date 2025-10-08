using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs;

public class MovementLocationConfig : IEntityTypeConfiguration<MovementLocation>
{
    public void Configure(EntityTypeBuilder<MovementLocation> builder)
    {
        builder.ToTable("MovementLocation");

        builder.HasKey(ml => ml.Id);
        builder.Property(ml => ml.Id).ValueGeneratedOnAdd();

        builder.Property(ml => ml.Name).HasMaxLength(100).IsRequired();

        builder.Property(ml => ml.Description).HasMaxLength(255);
    }
}