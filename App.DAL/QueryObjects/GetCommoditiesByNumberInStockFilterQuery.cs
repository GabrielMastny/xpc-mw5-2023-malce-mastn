using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;

namespace App.DAL.QueryObjects;

public class GetCommoditiesByNumberInStockFilterQuery : IQuery<CommodityEntity, NumberOfPiecesInStockFilter>
{
    public IEnumerable<CommodityEntity> Execute(NumberOfPiecesInStockFilter filter)
    {
        return Database.Instance.Commodities.Where(c => c.NumberOfPiecesInStock > filter.NumberOfPiecesInStock);
    }
}