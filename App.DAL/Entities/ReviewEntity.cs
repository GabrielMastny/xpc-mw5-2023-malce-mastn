using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record ReviewEntity : EntityBase, IReview
{
    public required int Stars { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}