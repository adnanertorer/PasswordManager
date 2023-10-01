#nullable enable
using CorePersistence.Paging;
using CorePersistence.Responses;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Services.UserAccountServices
{
    public interface IUserAccountService
    {
        Task<CoreResponse<UserAccountEntity>> Add(UserAccounts userAccount);
        Task<CoreResponse<UserAccountEntity>> Update(UserAccounts userAccount);
        Task<CoreResponse<UserAccountEntity>> Remove(UserAccounts userAccount);
        Task<CoreResponse<UserAccountEntity>> Get(Expression<Func<UserAccounts, bool>>? predicate);
        Task<CoreResponse<Paginate<UserAccountEntity>>> GetList(int? page, int? size, Expression<Func<UserAccounts, bool>>? predicate,
            Func<IQueryable<UserAccounts>, IOrderedQueryable<UserAccounts>>? orderBy = null);
    }
}
