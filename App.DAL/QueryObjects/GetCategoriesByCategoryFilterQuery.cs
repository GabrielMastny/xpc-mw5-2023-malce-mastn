using App.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace App.DAL.QueryObjects;

public class GetCategoryByCategoryFilterQuery : IQuery<CategoryEntity, CategoryFilter>
{
    public IEnumerable<CategoryEntity> Execute(CategoryFilter filter)
    {
        return Database.Instance.Categories.Where(c => c.Name == filter.Name);
    }
}