using System.Collections.Generic;
namespace App.DAL.Entities;

public record CommodityEntity : EntityBase
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required CategoryEntity Category { get; set; }
    public required ManufacturerEntity Manufacturer { get; set; }
    public ICollection<ReviewEntity> Reviews { get; } = new List<ReviewEntity>();
}