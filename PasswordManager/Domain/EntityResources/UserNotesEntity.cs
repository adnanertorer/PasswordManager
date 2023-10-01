using CorePersistence.Repository;

namespace PasswordManager.Domain.EntityResources;

public class UserNotesEntity:Entity
{
    public string UserId { get; set; }
    public string NoteTitle { get; set; }
    public string NoteText { get; set; }
}