using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Surname).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Password).IsRequired().HasMaxLength(50);
        builder.Property(b => b.Email).IsRequired().HasMaxLength(60);
        builder.Property(b => b.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(b => b.RefreshToken).HasMaxLength(150);
        builder.Property(b => b.OtpCode).HasMaxLength(6);
        builder.Property(b => b.EmailConfirmed).IsRequired();

        builder.Property(b => b.IsDeleted).IsRequired();
        builder.Property(b => b.CreatedBy).IsRequired();

        builder.HasQueryFilter(b => b.IsDeleted == false);
    }
}
