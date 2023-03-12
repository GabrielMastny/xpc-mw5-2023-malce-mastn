using App.DAL.Entities;

namespace App.DAL.Repositories;

public interface IRepository<TEntity> where TEntity : class, IEntity
{
    
}