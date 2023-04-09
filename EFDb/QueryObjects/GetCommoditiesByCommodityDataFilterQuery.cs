using App.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace EFDb.QueryObjects;

public class GetCommoditiesByCommodityDataFilterQuery : IQuery<CommodityEntity, CommodityDataFilter>
{
    public IEnumerable<CommodityEntity> Execute(CommodityDataFilter filter)
    {
        throw new NotImplementedException();
    }
}