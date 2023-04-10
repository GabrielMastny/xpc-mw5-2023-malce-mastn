using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;
using EFDb.Context;

namespace EFDb.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public GetReviewsByReviewFilterQuery(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        return _db.Reviews.Select(x => _mapper.Map<ReviewEntity>(x)).Where(x => x.Stars == filter.Stars);
    }
}