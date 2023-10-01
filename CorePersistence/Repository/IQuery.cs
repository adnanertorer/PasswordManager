using System.Linq;

namespace CorePersistence.Repository
{
    public interface IQuery<T> where T: Entity
    {
        IQueryable<T> Query();
    }
}