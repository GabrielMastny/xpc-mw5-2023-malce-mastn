using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;

namespace App.DAL.QueryObjects;

public class GetCommoditiesByCategoryFilterQuery : IQuery<CommodityEntity, CategoryFilter>
{
    public IEnumerable<CommodityEntity> Execute(CategoryFilter filter)
    {
        return Database.Instance.Commodities.Where(c => c.Category == filter._name);
    }
}