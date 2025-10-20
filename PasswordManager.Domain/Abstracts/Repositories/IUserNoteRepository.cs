using PasswordManager.Domain.Entities;

namespace PasswordManager.Domain.Abstracts.Repositories;

public interface IUserNoteRepository
{
    Task<UserNote> Add(UserNote userAccount, CancellationToken cancellationToken);
    void Update(UserNote category);
    Task<UserNote?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken);
    Task<IEnumerable<UserNote>> GetList(Guid userId, string? search, bool withAsNoTracking, CancellationToken cancellationToken);
}
