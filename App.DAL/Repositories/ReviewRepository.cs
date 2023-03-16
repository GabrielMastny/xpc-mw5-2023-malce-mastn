using App.DAL.Entities;

namespace App.DAL.Repositories;

public class ReviewRepository : IRepository<ReviewEntity>
{
    public Guid Create(ReviewEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        entity.Id = Guid.NewGuid();

        Database.Instance.Reviews.Add(entity);

        //Database.Instance.Manufacturers.Single(s => s._name == entity._manufacturer)._listOfCommodities.Add(entity);
        
        return entity.Id;
    }

    public ReviewEntity GetById(Guid id)
    {
        return Database.Instance.Reviews.Single(s => s.Id == id);
    }

    public ReviewEntity GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}