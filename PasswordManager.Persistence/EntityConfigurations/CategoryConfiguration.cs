using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.CategoryName).IsRequired().HasMaxLength(150);
        builder.Property(b => b.UserId).IsRequired();

        builder.Property(b => b.IsDeleted).IsRequired();
        builder.Property(b => b.CreatedBy).IsRequired();

        builder.HasOne(i => i.User)
            .WithMany(i => i.Categories)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(b => b.IsDeleted == false);
    }
}
