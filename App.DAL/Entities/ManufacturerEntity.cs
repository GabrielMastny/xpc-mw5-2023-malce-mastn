using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record ManufacturerEntity : EntityBase, IManufacturer
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
    public ICollection<CommodityEntity> ListOfCommodities { get; } = new List<CommodityEntity>();

    public static ManufacturerEntity Default()
    {
        return new ManufacturerEntity()
        {
            Description = string.Empty,
            Image = string.Empty,
            Name = string.Empty,
            CountryOfOrigin = string.Empty,
            ListOfCommodities = { },
            Id = Guid.Empty
        };
    }
    
    public static ManufacturerEntity Default(Guid id)
    {
        ManufacturerEntity man = ManufacturerEntity.Default();
        man.Id = id;
        return man;
    }

}