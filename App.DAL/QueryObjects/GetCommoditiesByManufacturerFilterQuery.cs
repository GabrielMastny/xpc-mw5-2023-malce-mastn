using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;

namespace App.DAL.QueryObjects;

public class GetCommoditiesByManufacturerFilterQuery : IQuery<CommodityEntity, ManufacturerFilter>
{
    public IEnumerable<CommodityEntity> Execute(ManufacturerFilter filter)
    {
        return Database.Instance.Commodities.Where(c => c.Manufacturer == filter.Name);
    }
}