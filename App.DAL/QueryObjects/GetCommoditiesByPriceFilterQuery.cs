using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;

namespace App.DAL.QueryObjects;

public class GetCommoditiesByPriceFilterQuery : IQuery<CommodityEntity, PriceFilter>
{
    public IEnumerable<CommodityEntity> Execute(PriceFilter filter)
    {
        return Database.Instance.Commodities.Where(c =>
        {
            //Console.WriteLine($"{c.Price}");
            //Console.WriteLine($"{filter.Operation}");
            return filter.Operation ? c.Price > filter.Price : c.Price < filter.Price;
        });
    }
}