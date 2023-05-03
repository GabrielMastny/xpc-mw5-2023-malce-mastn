using Eshop.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace Eshop.DAL.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        throw new NotImplementedException();
    }
}