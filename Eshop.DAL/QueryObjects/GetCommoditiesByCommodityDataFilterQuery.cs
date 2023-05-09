using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.QueryObjects;

public class GetCommoditiesByCommodityDataFilterQuery : IQuery<CommodityEntity, CommodityDataFilter>
{
    
    private readonly EshopContext _db;
    private readonly CommodityMapper _mapper;
    
    public GetCommoditiesByCommodityDataFilterQuery(EshopContext db, CommodityMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<CommodityEntity> Execute(CommodityDataFilter filter)
    {
        IEnumerable<CommodityEntity> list = _db.Commodities.Select(c => _mapper.ReverseMap(c));
        if (filter.Name != null)
        {
            list = list.Where(commodity => commodity.Name.Contains(filter.Name));
        }

        if (filter.Category != null)
        {
            list = list.Where(commodity => String.Equals(commodity.Category.Name, filter.Category, StringComparison.CurrentCultureIgnoreCase));
        }

        if (filter.Manufacturer != null)
        {
            list = list.Where(commodity => String.Equals(commodity.Manufacturer.Name, filter.Manufacturer, StringComparison.CurrentCultureIgnoreCase));
        }

        if (filter.Price != null)
        {
            list = list.Where(commodity => commodity.Price > filter.Price[0] && commodity.Price < filter.Price[1]);
        }

        if (filter.Weight != null)
        {
            list = list.Where(commodity => commodity.Weight > filter.Weight[0] && commodity.Weight < filter.Weight[1]);
        }

        if (filter.NumberOfPiecesInStock != null)
        {
            list = list.Where(commodity => commodity.NumberOfPiecesInStock > filter.NumberOfPiecesInStock);
        }
        return list;
    }
}