using System;
using System.Linq;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    public Guid Create(CommodityEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));

        entity.id = Guid.NewGuid();
        
        Database.Instance.Commodities.Add(entity);

        return entity.id;
    }

    public CommodityEntity GetById(Guid id)
    {
        return Database.Instance.Commodities.Single(s => s.id == id);
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