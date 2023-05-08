using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public record ManufacturerDataFilter : IFilter
{
    public string? Name { get; set; }
    public string? CountryOfOrigin { get; set; }
}