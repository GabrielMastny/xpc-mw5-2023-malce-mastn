using System.ComponentModel.DataAnnotations.Schema;
using CommonDbProperties.Interfaces.Entities;

namespace EFDb.Models;

[Table("Commodity")]
public class Commodity : TableBase, ICommodity
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required Guid CategoryId { get; set; }
    public required Guid ManufacturerId { get; set; }
}