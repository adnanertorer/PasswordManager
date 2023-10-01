using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CorePersistence.Paging;
using CorePersistence.Responses;
using CorePersistence.Tools;
using PasswordManager.Domain.EntityResources;
using PasswordManager.Domain.Repositories.CategoryRepositories;
using PasswordManager.Models;

namespace PasswordManager.Domain.Services.CategoryServices;

public class CategoryService:ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CoreResponse<CategoryEntity>> Add(Categories categories)
    {
        try
        {
            var result = Mapper.Map<CategoryEntity>(await _repository.AddAsync(categories));
            
            return new CoreResponse<CategoryEntity>(result, Messages.Successfull);
        }
        catch (Exception e)
        {
            return new CoreResponse<CategoryEntity>(Messages.ErrorMessage+$":{e.Message}");
        }
    }

    public async Task<CoreResponse<CategoryEntity>> Update(Categories categories)
    {
        try
        {
            var result = Mapper.Map<CategoryEntity>(await _repository.UpdateAsync(categories));
            return new CoreResponse<CategoryEntity>(result, Messages.Successfull);
        }
        catch (Exception e)
        {
            return new CoreResponse<CategoryEntity>(Messages.ErrorMessage+$":{e.Message}");
        }
    }

    public async Task<CoreResponse<CategoryEntity>> Remove(Categories categories)
    {
        try
        {
            var model = await _repository.GetAsync(i => i.Id == categories.Id);
            var result = Mapper.Map<CategoryEntity>(await _repository.DeleteAsync(model));
            return new CoreResponse<CategoryEntity>(result, Messages.Successfull);
        }
        catch (Exception e)
        {
            return new CoreResponse<CategoryEntity>(Messages.ErrorMessage+$":{e.Message}");
        }
    }

    public async Task<CoreResponse<CategoryEntity>> Get(Expression<Func<Categories, bool>> predicate)
    {
        try
        {
            var result = Mapper.Map<CategoryEntity>(await _repository.GetAsync(predicate));
            return new CoreResponse<CategoryEntity>(result, Messages.Successfull);
        }
        catch (Exception e)
        {
            return new CoreResponse<CategoryEntity>(Messages.ErrorMessage+$":{e.Message}");
        }
    }

    public async Task<CoreResponse<Paginate<CategoryEntity>>> GetList(int page, int size, Expression<Func<Categories, bool>> predicate,
            Func<IQueryable<Categories>, IOrderedQueryable<Categories>> orderBy = null)
    {
        try
        {
            var result = Mapper.Map<Paginate<CategoryEntity>>(await _repository.GetListAsync(predicate, orderBy: orderBy, index: page, size: size));
            return new CoreResponse<Paginate<CategoryEntity>>(result, Messages.Successfull);
        }
        catch (Exception e)
        {
            return new CoreResponse<Paginate<CategoryEntity>>(Messages.ErrorMessage+$":{e.Message}");
        }
    }
}