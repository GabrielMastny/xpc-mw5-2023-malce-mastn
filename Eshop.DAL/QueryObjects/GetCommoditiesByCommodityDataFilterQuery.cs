using Eshop.DAL.Entities;
using Eshop.DAL.Context;

namespace Eshop.DAL.QueryObjects;

public class GetCommoditiesByCommodityDataFilterQuery : IQuery<CommodityEntity, CommodityDataFilter>
{
    
    private readonly EshopContext _db;
    //private readonly IMapper _mapper;
    
    public GetCommoditiesByCommodityDataFilterQuery(EshopContext db)
    {
        _db = db;
        //_mapper = mapper;
    }
    public IEnumerable<CommodityEntity> Execute(CommodityDataFilter filter)
    {
        IEnumerable<CommodityEntity> list = null; //_db.Comodities.Select(c => _mapper.Map<CommodityEntity>(c));
        if (filter.Name != null)
        {
            list = list.Where(c => c.Name.Contains(filter.Name));
        }

        if (filter.Category != null)
        {
            list = list.Where(c => c.Category.Name == filter.Category);
        }

        if (filter.Manufacturer != null)
        {
            list = list.Where(c => c.Manufacturer.Name == filter.Manufacturer);
        }

        if (filter.Price != null)
        {
            list = list.Where(c => c.Price > filter.Price[0] && c.Price < filter.Price[1]);
        }

        if (filter.Weight != null)
        {
            list = list.Where(c => c.Weight > filter.Weight[0] && c.Weight < filter.Weight[1]);
        }

        if (filter.NumberOfPiecesInStock != null)
        {
            list = list.Where(c => c.NumberOfPiecesInStock > filter.NumberOfPiecesInStock);
        }
        return list;
    }
}