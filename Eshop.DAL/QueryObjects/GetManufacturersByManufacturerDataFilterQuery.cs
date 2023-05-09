using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.QueryObjects;

public class GetManufacturersByManufacturerDataFilterQuery : IQuery<ManufacturerEntity, ManufacturerDataFilter>
{
    
    private readonly EshopContext _db;
    private readonly ManufacturerMapper _mapper;
    
    public GetManufacturersByManufacturerDataFilterQuery(EshopContext db, ManufacturerMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<ManufacturerEntity> Execute(ManufacturerDataFilter filter)
    {
        IEnumerable<ManufacturerEntity> list = _db.Manufacturers.Select(m => _mapper.ReverseMap(m));
        if (filter.Name != null)
        {
            list = list.Where(manufacturer => manufacturer.Name.Contains(filter.Name));
        }

        if (filter.CountryOfOrigin != null)
        {
            list = list.Where(manufacturer => String.Equals(manufacturer.CountryOfOrigin, filter.CountryOfOrigin, StringComparison.CurrentCultureIgnoreCase));
        }
        return list;
    }
}