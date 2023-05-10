using AutoMapper;
using Eshop.DAL.Entities;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

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
        IEnumerable<ReviewEntity> list = _db.Reviews.Select(c => _mapper.Map<ReviewEntity>(c));

        if (filter.Stars != null)
        {
            list = list.Where(review => review.Stars == filter.Stars);
        }
        
        return list;
        
        
        
        //return _db.Reviews.Select(review => _mapper.Map<ReviewEntity>(review)).Where(c => c.Stars == filter.Stars);
    }
}