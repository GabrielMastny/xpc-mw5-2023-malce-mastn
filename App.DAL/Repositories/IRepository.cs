using App.DAL.Entities;

namespace App.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    Guid Create(TEntity? entity);
    TEntity GetById(Guid id);

    TEntity GetByName(string name);
    TEntity Update(TEntity? entity);
    void Delete(Guid id);
}