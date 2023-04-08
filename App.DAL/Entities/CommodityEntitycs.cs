using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record CommodityEntity : EntityBase, ICommodity
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

    public static CommodityEntity Default()
    {
        return new CommodityEntity()
        {
            Category = CategoryEntity.Default(),
            Description = string.Empty,
            Image = String.Empty,
            Manufacturer = ManufacturerEntity.Default(),
            Name = string.Empty,
            Price = 0,
            Reviews = new List<ReviewEntity>(),
            Weight = 0,
            NumberOfPiecesInStock = 0,
            Id = Guid.Empty
        };
    }
    
    public static CommodityEntity Default(Guid id)
    {
        var com = CommodityEntity.Default();
        com.Id = id;
        return com;
    }
}