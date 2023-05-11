using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetCommoditiesByCommodityDataFilterQuery : IQuery<CommodityEntity, CommodityDataFilter>
{
    
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public GetCommoditiesByCommodityDataFilterQuery(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<CommodityEntity> Execute(CommodityDataFilter filter)
    {
        IEnumerable<CommodityEntity> list = _db.Comodities.Select(commodity => _mapper.Map<CommodityEntity>(commodity));
        if (filter.Name != null)
        {
            list = list.Where(commodity => String.Equals(commodity.Name, filter.Name, StringComparison.CurrentCultureIgnoreCase));
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

        // foreach (var c in list)
        // {
        //     c.Manufacturer = _db.Manufacturers.Single(x => x.Id == c.Manufacturer.Id);
        //     c.Category = _db.Categories.Single(x => x.Id == c.Category.Id);
        // }
        
        return list;
    }
}