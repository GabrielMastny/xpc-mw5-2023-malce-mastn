using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace App.DAL.QueryObjects;

public class GetManufacturersByManufacturerDataFilterQuery : IQuery<ManufacturerEntity, ManufacturerDataFilter>
{
    public IEnumerable<ManufacturerEntity> Execute(ManufacturerDataFilter filter)
    {
        IEnumerable<ManufacturerEntity> list = Database.Instance.Manufacturers;
        
        if (filter.Name != null) list = list.Where(m => m.Name.Contains(filter.Name));
        if (filter.CountryOfOrigin != null) list = list.Where(m => m.CountryOfOrigin == filter.CountryOfOrigin);
        return list;
    }
}