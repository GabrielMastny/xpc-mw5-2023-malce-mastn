using CommonDbProperties.Interfaces.Entities;

namespace CommonDbProperties.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity : class, IWithId
{
    Guid Create(TEntity entity);
    IEnumerable<TEntity> Get();
    TEntity GetById(Guid id);
    TEntity Update(TEntity? entity);
    void Delete(Guid id);
}