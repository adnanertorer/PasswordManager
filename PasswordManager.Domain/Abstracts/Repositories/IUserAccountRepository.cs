using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Abstracts.Repositories;

public interface IUserAccountRepository
{
    Task<UserAccount> Add(UserAccount userAccount, CancellationToken cancellationToken);
    void Update(UserAccount category);
    Task<UserAccount?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken);
    Task<IEnumerable<UserAccount>> GetList(Guid userId, Guid? categoryId, string? search, bool withAsNoTracking, CancellationToken cancellationToken);
}
