namespace Eshop.DAL.QueryObjects.Filters;

public record ReviewFilter : IFilter
{
    public int Stars { get; set; }
}