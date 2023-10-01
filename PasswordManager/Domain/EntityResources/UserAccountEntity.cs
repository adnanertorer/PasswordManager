using CorePersistence.Repository;

namespace PasswordManager.Domain.EntityResources;

public class UserAccountEntity : Entity
{
    public string UserId { get; set; }
    public string AccountTitle { get; set; }
    public long? CategoryId { get; set; }
    public string AccountUrl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public virtual CategoryEntity Categories { get; set; }
}