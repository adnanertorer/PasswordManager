using CorePersistence.Repository;
using PasswordManager.Models;

namespace PasswordManager.Domain.Repositories.CategoryRepositories
{
    public class CategoryRepository:Repository<Categories, Entities>, ICategoryRepository
    {
        public CategoryRepository(Entities context) : base(context)
        {
        }
    }
}