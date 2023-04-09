using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;
using ArgumentNullException = System.ArgumentNullException;

namespace App.DAL.Repositories;

public class ReviewRepository : IRepository<ReviewEntity>
{
    public Guid Create(ReviewEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        entity.Id = Guid.NewGuid();
        Database.Instance.Reviews.Add(entity);
        return entity.Id;
    }

    public IEnumerable<ReviewEntity> Get()
    {
        return Database.Instance.Reviews;
    }

    public ReviewEntity GetById(Guid id)
    {
        if (Database.Instance.Reviews.All(r => r.Id != id)) throw new ArgumentNullException();
        return Database.Instance.Reviews.Single(r => r.Id == id);
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (Database.Instance.Reviews.All(r => r.Id != entity.Id)) throw new ArgumentNullException(nameof(entity));
        var review = Database.Instance.Reviews.Single(r => r.Id == entity.Id);
        review.Description = entity.Description;
        review.Title = entity.Title;
        review.Stars = entity.Stars;
        return review;
    }

    public void Delete(Guid id)
    {
        if(Database.Instance.Commodities.All(r => r.Id != id)) throw new ArgumentException();
        var review = Database.Instance.Reviews.Single(r => r.Id == id);
        Database.Instance.Reviews.Remove(review);
    }
}