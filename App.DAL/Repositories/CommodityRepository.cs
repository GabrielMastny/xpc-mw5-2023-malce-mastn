using System;
using System.Linq;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    public Guid Create(CommodityEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        entity.Id = Guid.NewGuid();
        entity.Reviews = new List<ReviewEntity>();
        
        Database.Instance.Manufacturers.Single(m => m.Name == entity.Manufacturer).ListOfCommodities.Add(entity);
        //Database.Instance.Categories.Single(c => c.Name == entity.Name).
        
        Database.Instance.Commodities.Add(entity);

        return entity.Id;
    }

    public CommodityEntity GetById(Guid id)
    {
        return Database.Instance.Commodities.Single(s => s.Id == id);
    }

    public CommodityEntity GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}