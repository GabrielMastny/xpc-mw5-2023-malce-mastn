using Eshop.DAL.Entities;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetCommoditiesByCommodityDataFilterQuery : IQuery<CommodityEntity, CommodityDataFilter>
{
    
    private readonly EshopContext _db;

    public GetCommoditiesByCommodityDataFilterQuery(EshopContext db)
    {
        _db = db;
    }
    public IEnumerable<CommodityEntity> Execute(CommodityDataFilter filter)
    {
        IEnumerable<CommodityEntity> list = _db.Comodities.Select(y => new CommodityEntity
        {
            Description = y.Description,
            Image = y.Image,
            Name = y.Name,
            Price = y.Price,
            Weight = y.Weight,
            Category = new CategoryEntity
            {
                Description = y.Category.Description,
                Id = y.Category.Id,
                Image = y.Category.Description,
                Name = y.Category.Name
            },
            Id = y.Id,
            Manufacturer = new ManufacturerEntity
            {
                Description = y.Manufacturer.Description,
                Id = y.Manufacturer.Id,
                Image = y.Manufacturer.Image,
                Name = y.Manufacturer.Name,
                CountryOfOrigin = y.Manufacturer.CountryOfOrigin
            },
            NumberOfPiecesInStock = y.NumberOfPiecesInStock,

        });
        
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

        return list;
    }
}