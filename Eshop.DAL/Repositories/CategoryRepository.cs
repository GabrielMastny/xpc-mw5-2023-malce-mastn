using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{

    private readonly EshopContext _db;
    private readonly CategoryMapper _mapper;
    public CategoryRepository(EshopContext eshopContext, CategoryMapper mapper)
    {
        _db = eshopContext;
        _mapper = mapper;
    }
    
    public Guid Create(CategoryEntity entity)
    {
        var category = _mapper.Map(entity);

        _db.Categories.Add(category);
        _db.SaveChanges();

        return entity.Id;
    }

    public CategoryEntity GetById(Guid id)
    {
        var c = _db.Categories.Single(category => category.Id == id.ToString());
        return _mapper.ReverseMap(c);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (!_db.Categories.Any(category => entity != null && category.Id == entity.Id.ToString()) || entity == null)
        {
            throw new ArgumentNullException();
        }

        _db.Categories.Update(_mapper.Map(entity));
        _db.SaveChanges();
        return entity;
    }

    public void Delete(Guid id)
    {
        var category = _db.Categories.Single(category => category.Id == id.ToString());
        if (category == null) throw new ArgumentNullException();
        var commoditiesToRemove = _db.Commodities.Where(commodity => commodity.CategoryId == category.Id);
        foreach (var commodity in commoditiesToRemove)
        {
            _db.Commodities.Remove(commodity);
        }
        _db.Categories.Remove(category);
        _db.SaveChanges();
    }

}