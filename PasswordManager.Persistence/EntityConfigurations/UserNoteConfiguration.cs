using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.EntityConfigurations;

public class UserNoteConfiguration : IEntityTypeConfiguration<UserNote>
{
    public void Configure(EntityTypeBuilder<UserNote> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.NoteTitle).IsRequired().HasMaxLength(150);
        builder.Property(b => b.NoteText).IsRequired();
        builder.Property(b => b.UserId).IsRequired();

        builder.Property(b => b.IsDeleted).IsRequired();
        builder.Property(b => b.CreatedBy).IsRequired();

        builder.HasOne(i => i.User)
            .WithMany(i => i.UserNotes)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(b => b.IsDeleted == false);
    }
}
