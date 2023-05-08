using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.DAL.Entities;

//[Table("Review")]
public record ReviewEntity : EntityBase //TableBase, IReview
{
    public string Description { get; set; }
    public string Title { get; set; }
    public required int Stars { get; set; }
    
    public required Guid Commodity { get; set; }
    
}