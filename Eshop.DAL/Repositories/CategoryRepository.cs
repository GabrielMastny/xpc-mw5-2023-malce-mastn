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
        //throw new NotImplementedException();
    }

    public CategoryEntity GetById(Guid id)
    {
        var c = _db.Categories.Single(x => x.Id == id.ToString());
        return _mapper.ReverseMap(c);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        var c = _db.Categories.Single(x => x.Id == id.ToString());

        if (c == null) throw new ArgumentNullException();

        _db.Categories.Remove(c);

    }

}