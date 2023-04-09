using CommonDbProperties.Interfaces.Entities;
using CommonDbProperties.Interfaces.Filters;

namespace CommonDbProperties.Interfaces.QueryObjects;

public interface IQuery<TModel, TFilter> where TModel : IWithId where TFilter : IFilter
{
    IEnumerable<TModel> Execute(TFilter filter);
}