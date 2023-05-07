using CommonDbProperties.Interfaces.Filters;

namespace CommonDbProperties.Interfaces.QueryObjects;

public interface IQuery<TModel, TFilter> where TFilter : IFilter
{
    IEnumerable<TModel> Execute(TFilter filter);
} 