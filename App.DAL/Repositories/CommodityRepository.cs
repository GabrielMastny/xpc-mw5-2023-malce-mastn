using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;

namespace App.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    public Guid Create(CommodityEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity));
        entity.Id = Guid.NewGuid();
        Database.Instance.Manufacturers.Single(m => m.Name == entity.Manufacturer.Name).ListOfCommodities.Add(entity);
        Database.Instance.Commodities.Add(entity);
        return entity.Id;
    }

    public IEnumerable<CommodityEntity> Get()
    {
        return Database.Instance.Commodities;
    }

    public CommodityEntity GetById(Guid id)
    {
        if (Database.Instance.Commodities.All(c => c.Id != id)) throw new ArgumentNullException();
        return Database.Instance.Commodities.Single(c => c.Id == id);
    }

    public CommodityEntity GetByName(string name)
    {
        if(name == null) throw new ArgumentNullException();
        if (Database.Instance.Commodities.All(c => c.Name != name)) throw new ArgumentNullException(nameof(name));
        return Database.Instance.Commodities.Single(c => c.Name == name);
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (Database.Instance.Commodities.All(c => c.Id != entity.Id)) throw new ArgumentNullException(nameof(entity));
        var commodity = Database.Instance.Commodities.Single(c => c.Id == entity.Id);
        commodity.Name = entity.Name;
        commodity.Description = entity.Description;
        commodity.Price = entity.Price;
        return commodity;
    }

    public void Delete(Guid id)
    {
        if(Database.Instance.Commodities.All(c => c.Id != id)) throw new ArgumentException();
        var commodity = Database.Instance.Commodities.Single(c => c.Id == id);
        Database.Instance.Manufacturers.Single(m => m == commodity.Manufacturer).ListOfCommodities.Remove(commodity);
        foreach (var r in commodity.Reviews)
        {
            Database.Instance.Reviews.Remove(r);
        }
        Database.Instance.Commodities.Remove(commodity);
    }
}