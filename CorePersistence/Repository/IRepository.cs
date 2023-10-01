#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CorePersistence.Paging;

namespace CorePersistence.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetAsync(
            Expression<Func<T, bool>>? predicate,
            bool enableTracking = true, CancellationToken cancellationToken = default);
        
        Task<Paginate<T>> GetListAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? index = 0,
            int? size = 10,
            bool enableTracking = true, CancellationToken cancellationToken = default);
        
        Task<bool> AnyAsync(
            Expression<Func<T, bool>>? predicate = null,
            bool enableTracking = true, CancellationToken cancellationToken = default);
        
        Task<T> AddAsync(T entity);
        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entities);
    }
}
