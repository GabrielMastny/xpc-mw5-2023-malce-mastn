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
        IEnumerable<CommodityEntity> list = _db.Comodities.Select(c => _mapper.Map<CommodityEntity>(c));
        if (filter.Name != null)
        {
            list = list.Where(commodity => commodity.Name.Contains(filter.Name));
        }

        if (filter.Category != null)
        {
            list = list.Where(commodity => commodity.Category.Name == filter.Category);
        }

        if (filter.Manufacturer != null)
        {
            list = list.Where(commodity => commodity.Manufacturer.Name == filter.Manufacturer);
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