using Adoroid.Core.Repository.Repositories;

namespace PasswordManager.Domain.Entities;

public class UserNote : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string NoteTitle { get; set; }
    public string NoteText { get; set; }

    public User User { get; set; } 
}
