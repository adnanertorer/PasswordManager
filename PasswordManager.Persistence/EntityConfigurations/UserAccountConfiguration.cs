using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.EntityConfigurations;

public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.AccountTitle).IsRequired().HasMaxLength(150);
        builder.Property(b => b.Username).IsRequired().HasMaxLength(50);
        builder.Property(b => b.UserId).IsRequired();
        builder.Property(b => b.AccountUrl).IsRequired();
        builder.Property(b => b.Password).IsRequired().HasMaxLength(60);
        builder.Property(b => b.Username).IsRequired().HasMaxLength(60);

        builder.Property(b => b.IsDeleted).IsRequired();
        builder.Property(b => b.CreatedBy).IsRequired();

        builder.HasOne(i => i.User)
            .WithMany(i => i.UserAccounts)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(b => b.IsDeleted == false);
    }
}
