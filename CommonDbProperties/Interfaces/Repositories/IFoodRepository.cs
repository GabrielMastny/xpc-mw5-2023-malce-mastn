using CommonDbProperties.Interfaces.Entities;

namespace CommonDbProperties.Interfaces.Repositories;

public interface IFoodRepository<TEntity> : IRepository<TEntity> where TEntity : class, IWithId
{
    
}