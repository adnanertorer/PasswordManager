#nullable enable
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CorePersistence.Paging;
using CorePersistence.Responses;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Models;

namespace PasswordManager.Domain.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<CoreResponse<CategoryEntity>> Add(Categories categories);
        Task<CoreResponse<CategoryEntity>> Update(Categories categories);
        Task<CoreResponse<CategoryEntity>> Remove(Categories categories);
        Task<CoreResponse<CategoryEntity>> Get(Expression<Func<Categories, bool>>? predicate);
        Task<CoreResponse<Paginate<CategoryEntity>>> GetList(int page, int size, Expression<Func<Categories, bool>>? predicate,
            Func<IQueryable<Categories>, IOrderedQueryable<Categories>>? orderBy = null);
    }
}