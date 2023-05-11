namespace Eshop.DAL.QueryObjects.Filters;

public record CommodityDataFilter : IFilter
{
    public string? Name { get; set; }
    public double[]? Price { get; set; }
    public double[]? Weight { get; set; }
    public int? NumberOfPiecesInStock { get; set; }
    public string? Category { get; set; }
    public string? Manufacturer { get; set; }
}