using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;

namespace App.DAL.QueryObjects;

public interface IQuery<TModel, TFilter> where TModel : IEntity where TFilter : IFilter
{
    IEnumerable<TModel> Execute(TFilter filter);
}