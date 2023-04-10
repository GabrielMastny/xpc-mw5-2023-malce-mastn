﻿using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;
using AutoMapper;
using CommonDbProperties.Interfaces.QueryObjects;
using EFDb.Context;

namespace EFDb.QueryObjects;

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
        IEnumerable<ManufacturerEntity> list = _db.Comodities.Select(m => _mapper.Map<ManufacturerEntity>(m));
        if (filter.Name != null) list = list.Where(m => m.Name.Contains(filter.Name));
        if (filter.CountryOfOrigin != null) list = list.Where(m => m.CountryOfOrigin == filter.CountryOfOrigin);
        return list;
    }
}