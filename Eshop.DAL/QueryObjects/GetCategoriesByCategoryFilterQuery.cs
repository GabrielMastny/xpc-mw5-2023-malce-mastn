﻿using AutoMapper;
using Eshop.DAL.Context;
using Eshop.DAL.Entities;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetCategoriesByCategoryFilterQuery : IQuery<CategoryEntity, CategoryFilter>
{
    
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public GetCategoriesByCategoryFilterQuery(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public IEnumerable<CategoryEntity> Execute(CategoryFilter filter)
    {
        return _db.Categories.Select(category => _mapper.Map<CategoryEntity>(category)).Where(category => category.Name == filter.Name);
    }
}