namespace PasswordManager.Domain.Abstracts.Repositories;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    IUserAccountRepository UserAccountRepository { get; }
    IUserNoteRepository UserNoteRepository { get; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}
