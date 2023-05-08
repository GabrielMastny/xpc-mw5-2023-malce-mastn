using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public class ReviewMapper : IMapper<ReviewEntity, Review>
{
    public Review Map(ReviewEntity entity)
    {
        return new Review()
        {
            Id = entity.Id.ToString(),
            Stars = entity.Stars,
            Description = entity.Description,
            Title = entity.Title,
            CommodityId = entity.Commodity.ToString()
        };
    }

    public ReviewEntity ReverseMap(Review model)
    {
        return new ReviewEntity()
        {
            Id = Guid.Parse(model.Id),
            Stars = model.Stars,
            Description = model.Description,
            Title = model.Title,
            Commodity = Guid.Parse(model.CommodityId)
        };
    }
}