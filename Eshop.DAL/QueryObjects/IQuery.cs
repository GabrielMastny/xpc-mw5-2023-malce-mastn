using Eshop.DAL.QueryObjects.Filters;

namespace Eshop.DAL.QueryObjects;

public interface IQuery<TModel, TFilter> where TFilter : IFilter
{
    IEnumerable<TModel> Execute(TFilter filter);
} 