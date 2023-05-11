using System.ComponentModel.DataAnnotations.Schema;
using Eshop.DAL.Entities;

namespace Eshop.DAL.Entities;

[Table("Commodity")]
public class CommodityEntity : TableBase
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public CategoryEntity Category { get; set; }
    public ManufacturerEntity Manufacturer { get; set; }
}