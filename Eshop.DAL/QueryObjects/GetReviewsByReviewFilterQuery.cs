using Eshop.DAL.Entities;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    
    private readonly EshopContext _db;

    public GetReviewsByReviewFilterQuery(EshopContext db)
    {
        _db = db;
    }
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        IEnumerable<ReviewEntity> list = _db.Reviews.ToList();

        if (filter.Stars != null)
        {
            list = list.Where(review => review.Stars == filter.Stars);
        }
        
        return list;
    }
}