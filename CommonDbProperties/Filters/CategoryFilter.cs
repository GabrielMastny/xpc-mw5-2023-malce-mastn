namespace CommonDbProperties.Interfaces.Filters;

public record CategoryFilter : IFilter
{
    public string Name { get; set; }
}