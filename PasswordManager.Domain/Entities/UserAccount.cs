using Adoroid.Core.Repository.Repositories;

namespace PasswordManager.Domain.Entities;

public class UserAccount : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string AccountTitle { get; set; }
    public Guid? CategoryId { get; set; }
    public string AccountUrl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public User User { get; set; }
    public Category? Category { get; set; }
}
