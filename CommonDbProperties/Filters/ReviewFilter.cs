namespace CommonDbProperties.Interfaces.Filters;

public record ReviewFilter : IFilter
{
    public int Stars { get; set; }
}