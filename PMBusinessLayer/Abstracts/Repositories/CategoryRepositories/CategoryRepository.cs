using System.Data.Entity;
using CorePersistence.Repository;
using PMBusinessLayer.Entities;

namespace PMBusinessLayer.Abstracts.Repositories.CategoryRepositories
{
    public class CategoryRepository:Repository<CategoryModel, DbContext>, ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}