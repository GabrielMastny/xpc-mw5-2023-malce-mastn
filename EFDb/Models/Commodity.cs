using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;

namespace EFDb.Models;

[Table("Commodity")]
public class Commodity : TableBase
{
    public required string Name { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required Category Category { get; set; }
    public required Manufacturer Manufacturer { get; set; }
    public ICollection<Review> Reviews { get; set; }
}