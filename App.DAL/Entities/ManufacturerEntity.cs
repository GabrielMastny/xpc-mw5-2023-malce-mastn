using System.Collections.Generic;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record ManufacturerEntity : EntityBase, IManufacturer
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
    public ICollection<CommodityEntity> ListOfCommodities { get; } = new List<CommodityEntity>();

}