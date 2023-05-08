using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.DAL.Entities;

//[Table("Commodity")]
public record CommodityEntity : EntityBase //TableBase
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required CategoryEntity Category { get; set; }
    public required ManufacturerEntity Manufacturer { get; set; }
    public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
}