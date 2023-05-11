﻿using Eshop.DAL.Entities;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetManufacturersByManufacturerDataFilterQuery : IQuery<ManufacturerEntity, ManufacturerDataFilter>
{
    
    private readonly EshopContext _db;
   
    public GetManufacturersByManufacturerDataFilterQuery(EshopContext db)
    {
        _db = db;
    }
    public IEnumerable<ManufacturerEntity> Execute(ManufacturerDataFilter filter)
    {
        IEnumerable<ManufacturerEntity> list = _db.Manufacturers.ToList();
        
        if (filter.Name != null)
        {
            list = list.Where(manufacturer => String.Equals(manufacturer.Name, filter.Name, StringComparison.CurrentCultureIgnoreCase));
        }

        if (filter.CountryOfOrigin != null)
        {
            list = list.Where(manufacturer => String.Equals(manufacturer.CountryOfOrigin, filter.CountryOfOrigin, StringComparison.CurrentCultureIgnoreCase));
        }
        return list;
    }
}