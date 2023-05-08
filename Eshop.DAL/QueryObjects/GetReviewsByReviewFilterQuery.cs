using Eshop.DAL.Entities;
using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        throw new NotImplementedException();
    }
}