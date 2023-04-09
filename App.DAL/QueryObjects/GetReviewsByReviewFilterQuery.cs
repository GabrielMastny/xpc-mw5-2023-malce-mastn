using App.DAL.Entities;
using CommonDbProperties.Interfaces.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace App.DAL.QueryObjects;

public class GetReviewsByReviewFilterQuery : IQuery<ReviewEntity, ReviewFilter>
{
    public IEnumerable<ReviewEntity> Execute(ReviewFilter filter)
    {
        return Database.Instance.Reviews.Where(r => r.Stars == filter.Stars);
    }
}