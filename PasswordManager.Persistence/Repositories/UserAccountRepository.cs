using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Abstracts.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.Repositories;

public class UserAccountRepository(PasswordManagerDbContext dbContext) : IUserAccountRepository
{
    public async Task<UserAccount> Add(UserAccount userAccount, CancellationToken cancellationToken)
    {
        await dbContext.UsersAccounts.AddAsync(userAccount, cancellationToken);
        return userAccount;
    }

    public async Task<UserAccount?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContext.UsersAccounts
            .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        return await dbContext.UsersAccounts.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<UserAccount>> GetList(Guid userId, Guid? categoryId, string? search, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContext.UsersAccounts
          .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        query = query.Where(i => i.UserId == userId);

        if(categoryId.HasValue)
            query = query.Where(i => i.CategoryId == categoryId.Value);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(i => i.AccountTitle.Contains(search) || i.AccountUrl.Contains(search) || i.Username.Contains(search));

        return await query.OrderByDescending(i => i.CreatedDate).ToListAsync(cancellationToken);
    }

    public void Update(UserAccount category)
    {
        dbContext.UsersAccounts.Update(category);
    }
}
