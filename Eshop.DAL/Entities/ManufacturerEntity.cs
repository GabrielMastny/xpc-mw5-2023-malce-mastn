using System.ComponentModel.DataAnnotations.Schema;
//using Eshop.DAL.Models;

namespace Eshop.DAL.Entities;

//Table("Manufacturer")]
public record ManufacturerEntity : EntityBase //TableBase, IManufacturer
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
    public ICollection<CommodityEntity> ListOfCommodities { get; } = new List<CommodityEntity>();
}