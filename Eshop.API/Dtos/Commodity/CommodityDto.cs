using System.Collections.Generic;

namespace Eshop.API.Dtos;

public class CommodityDto
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    // public IEnumerable<ReviewDTO> Reviews
    // {
    //     get;
    //     set;
    // }
}