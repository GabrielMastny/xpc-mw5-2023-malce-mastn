using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetManufacturersByManufacturerDataFilterQuery : IQuery<ManufacturerEntity, ManufacturerDataFilter>
{
    
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public GetManufacturersByManufacturerDataFilterQuery(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<ManufacturerEntity> Execute(ManufacturerDataFilter filter)
    {
        IEnumerable<ManufacturerEntity> list = _db.Comodities.Select(manufacturer => _mapper.Map<ManufacturerEntity>(manufacturer));
        
        if (filter.Name != null)
        {
            list = list.Where(manufacturer => manufacturer.Name.Contains(filter.Name));
        }

        if (filter.CountryOfOrigin != null)
        {
            list = list.Where(manufacturer => manufacturer.CountryOfOrigin == filter.CountryOfOrigin);
        }
        return list;
    }
}