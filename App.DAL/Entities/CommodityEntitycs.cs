using System.Collections.Generic;
namespace App.DAL.Entities;

public record CommodityEntity : EntityBase
{
    public required string _name { get; set; }
    public string _image { get; set; }
    public string _description { get; set; }
    public required double _price { get; set; }
    public double _weight { get; set; }
    public int _numberOfPiecesInStock { get; set; }
    public required string _category { get; set; }
    public required string _manufacturer { get; set; }
    public ICollection<ReviewEntity> _reviews { get; set; }
}