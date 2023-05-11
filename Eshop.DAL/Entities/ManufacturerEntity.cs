using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.DAL.Entities;

[Table("Manufacturer")]
public class ManufacturerEntity : TableBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
}