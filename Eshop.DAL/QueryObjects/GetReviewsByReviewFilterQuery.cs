using AutoMapper;
using Eshop.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;
using Eshop.DAL.Context;

namespace Eshop.DAL.QueryObjects;

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
        return _db.Reviews.Select(c => _mapper.Map<ReviewEntity>(c)).Where(c => c.Stars == filter.Stars);
    }
}