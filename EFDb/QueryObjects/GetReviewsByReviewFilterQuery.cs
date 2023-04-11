using App.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace EFDb.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        throw new NotImplementedException();
    }
}