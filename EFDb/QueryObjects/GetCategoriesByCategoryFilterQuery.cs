using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;
using EFDb.Context;

namespace EFDb.QueryObjects;

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
        return _db.Categories.Select(c => _mapper.Map<CategoryEntity>(c)).Where(c => c.Name == filter.Name);
    }
}