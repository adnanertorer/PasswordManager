using Adoroid.Core.Repository.Repositories;

namespace PasswordManager.Domain.Entities;

public class Category : Entity<Guid>
{
    public string CategoryName { get; set; }
    public Guid UserId { get; set; }

    public User User { get; set; }
}
