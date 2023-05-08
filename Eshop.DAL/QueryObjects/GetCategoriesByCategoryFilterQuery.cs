using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetCategoriesByCategoryFilterQuery : IQuery<CategoryEntity, CategoryFilter>
{
    
    private readonly EshopContext _db;
    private readonly CategoryMapper _mapper;
    
    public GetCategoriesByCategoryFilterQuery(EshopContext db, CategoryMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public IEnumerable<CategoryEntity> Execute(CategoryFilter filter)
    {
        return _db.Categories.Select(c => _mapper.ReverseMap(c)).Where(c => c.Name == filter.Name);
    }
}