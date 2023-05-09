using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    
    private readonly EshopContext _db;
    private readonly ReviewMapper _mapper;
    
    public GetReviewsByReviewFilterQuery(EshopContext db, ReviewMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        return _db.Reviews.Select(review => _mapper.ReverseMap(review)).Where(review => review.Stars == filter.Stars);
    }
}