using App.DAL.QueryObjects.Filters;
using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.QueryObjects;

public interface IQuery<TModel, TFilter> where TModel : IWithId where TFilter : IFilter
{
    IEnumerable<TModel> Execute(TFilter filter);
}