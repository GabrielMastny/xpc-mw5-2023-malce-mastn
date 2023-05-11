using Eshop.DAL.Context;
using Eshop.DAL.Entities;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetCategoriesByCategoryFilterQuery : IQuery<CategoryEntity, CategoryFilter>
{
    
    private readonly EshopContext _db;

    public GetCategoriesByCategoryFilterQuery(EshopContext db)
    {
        _db = db;
    }
    
    public IEnumerable<CategoryEntity> Execute(CategoryFilter filter)
    {
        IEnumerable<CategoryEntity> list =  _db.Categories.ToList();

        if (filter.Name != null)
        {
            list = list.Where(category => String.Equals(category.Name, filter.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        return list;
    }
}