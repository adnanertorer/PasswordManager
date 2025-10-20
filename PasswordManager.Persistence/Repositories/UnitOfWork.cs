using Microsoft.EntityFrameworkCore.Storage;
using PasswordManager.Domain.Abstracts.Repositories;

namespace PasswordManager.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly PasswordManagerDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public ICategoryRepository CategoryRepository { get; }

    public IUserAccountRepository UserAccountRepository { get; }

    public IUserNoteRepository UserNoteRepository { get; }

    public UnitOfWork(PasswordManagerDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        CategoryRepository = new CategoryRepository(dbContext);
        UserAccountRepository = new UserAccountRepository(dbContext);
        UserNoteRepository = new UserNoteRepository(dbContext);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        _transaction ??= await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync(CancellationToken cancellationToken)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
