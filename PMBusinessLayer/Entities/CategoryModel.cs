using CorePersistence.Repository;

namespace PMBusinessLayer.Entities
{
    public abstract class CategoryModel:Entity
    {
        public string CategoryName { get; set; }
        public string UserId { get; set; }
    }
}