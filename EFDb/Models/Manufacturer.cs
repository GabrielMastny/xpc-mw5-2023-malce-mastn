using System.ComponentModel.DataAnnotations.Schema;
using CommonDbProperties.Interfaces.Entities;

namespace EFDb.Models;

[Table("Manufacturer")]
public class Manufacturer : TableBase, IManufacturer
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
}