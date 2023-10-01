using CorePersistence.Repository;

namespace PasswordManager.Domain.EntityResources;

public class CategoryEntity:Entity
{
    public string CategoryName { get; set; }
    public string UserId { get; set; }
}