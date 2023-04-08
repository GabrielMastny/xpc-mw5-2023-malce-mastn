using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record ReviewEntity : EntityBase, IReview
{
    public required int Stars { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public CommodityEntity RelatedTo { get; set; }

    public static ReviewEntity Default()
    {
        return new ReviewEntity
        {
            Description = String.Empty,
            Stars = 0,
            Title = string.Empty,
            Id = Guid.Empty
        };
    }
}