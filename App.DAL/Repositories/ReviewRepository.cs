﻿using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;

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

    public IEnumerable<ReviewEntity> Get()
    {
        return Database.Instance.Reviews;
    }

    public ReviewEntity GetById(Guid id)
    {
        return Database.Instance.Reviews.Single(s => s.Id == id);
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        if(!Database.Instance.Commodities.Any(c => c.Id == id)) throw new ArgumentException();
                
        var review = Database.Instance.Reviews.Single(s => s.Id == id);
        Database.Instance.Reviews.Remove(review);
    }
}