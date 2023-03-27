using System.Collections.Generic;
namespace App.DAL.Entities;

public record ManufacturerEntity : EntityBase
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
    public ICollection<CommodityEntity> ListOfCommodities { get; } = new List<CommodityEntity>();

}