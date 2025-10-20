using Microsoft.EntityFrameworkCore;
using PasswordManager.Domain.Abstracts.Repositories;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Persistence.Repositories;

public class CategoryRepository(PasswordManagerDbContext dbContext) : ICategoryRepository
{
    public async Task<Category> Add(Category category, CancellationToken cancellationToken)
    {
        await dbContext.Categories.AddAsync(category, cancellationToken);
        return category;
    }

    public async Task<Category?> GetById(Guid id, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContext.Categories
            .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(i => i.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<Category>> GetList(Guid userId, bool withAsNoTracking, CancellationToken cancellationToken)
    {
        var query = dbContext.Categories
            .AsQueryable();

        if (withAsNoTracking)
            query = query.AsNoTracking();

        return await query.Where(i => i.UserId == userId).OrderBy(i => i.CategoryName).ToListAsync(cancellationToken);
    }

    public void Update(Category category)
    {
        dbContext.Categories.Update(category);
    }
}
