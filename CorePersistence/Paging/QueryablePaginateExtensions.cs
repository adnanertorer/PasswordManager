using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CorePersistence.Paging
{

    public static class QueryablePaginateExtensions
    {
        public static async Task<Paginate<T>> ToPaginateAsync<T>(
            this IQueryable<T> source,
            int? index, int? size, CancellationToken cancellationToken = default)
        {
            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            List<T> items;
            if(index.HasValue && size.HasValue)
            {
                items = await source.Skip(index.Value * size.Value).Take(size.Value).ToListAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                items = await source.ToListAsync(cancellationToken).ConfigureAwait(false);
            }
            
            Paginate<T> list = new()
            {
                Count = count,
                Index = index,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size),
                Size = items.Count
            };
            return list;
        }

        public static Paginate<T> ToPaginate<T>(
            this IQueryable<T> source,
            int? index, int? size)
        {
            var count = source.Count();
            List<T> items;
            if (index.HasValue && size.HasValue)
            {
                items = source.Skip(index.Value * size.Value).Take(size.Value).ToList();
            }
            else
            {
                items = source.ToList();
            }
            Paginate<T> list = new()
            {
                Count = count,
                Index = index,
                Items = items,
                Pages = (int)Math.Ceiling(count / (double)size),
                Size = items.Count
            };
            return list;
        }
    }
}