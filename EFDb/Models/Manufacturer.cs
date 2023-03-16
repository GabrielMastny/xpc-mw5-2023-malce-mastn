using System.ComponentModel.DataAnnotations.Schema;

namespace EFDb.Models;

[Table("Manufacturer")]
public class Manufacturer : TableBase
{
    public string Name { get; set; }
}