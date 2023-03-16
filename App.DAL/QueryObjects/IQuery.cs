namespace App.DAL.QueryObjects;

public interface IQuery<TModel, TFilter>
{
    IEnumerable<TModel> Execute(TFilter filter);
}