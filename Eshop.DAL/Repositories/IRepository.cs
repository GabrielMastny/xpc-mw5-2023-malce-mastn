using Eshop.DAL.Entities;

namespace Eshop.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : EntityBase
{
    Guid Create(TEntity entity);
    TEntity GetById(Guid id);
    TEntity Update(TEntity? entity);
    void Delete(Guid id);
}