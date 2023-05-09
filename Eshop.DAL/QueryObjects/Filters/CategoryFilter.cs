namespace Eshop.DAL.QueryObjects.Filters;

public record CategoryFilter : IFilter
{
    public string Name { get; set; }
}