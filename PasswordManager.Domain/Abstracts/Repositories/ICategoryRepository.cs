using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Abstracts.Repositories;

public interface ICategoryRepository
{
    Task<Category> Add(Category category, CancellationToken cancellationToken);
    void Update(Category category);
    Task<Category?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken);
    Task<IEnumerable<Category>> GetList(Guid userId, bool withAsNoTracking, CancellationToken cancellationToken);
}
