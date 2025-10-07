using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User_");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();

        builder.Property(u => u.Email).HasMaxLength(100);

        builder.Property(u => u.Password).HasMaxLength(255);

        builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId);

        builder.HasMany(u => u.Roles).WithMany(r => r.Users);
    }
}