namespace App.DAL.QueryObjects.Filters;

public record ManufacturerDataFilter : IFilter
{
    public string? Name { get; set; }
    public string? CountryOfOrigin { get; set; }
}