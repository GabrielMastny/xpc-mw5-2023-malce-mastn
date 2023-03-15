namespace WebAPI.Dtos;

public class CommodityCreateDto
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required string Category { get; set; }
    public required string Manufacturer { get; set; }
}