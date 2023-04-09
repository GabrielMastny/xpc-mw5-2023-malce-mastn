using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;

namespace App.DAL.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    public Guid Create(ManufacturerEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException();
        entity.Id = Guid.NewGuid();
        Database.Instance.Manufacturers.Add(entity);
        return entity.Id;
    }
    
    public IEnumerable<ManufacturerEntity> Get()
    {
        return Database.Instance.Manufacturers;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        if (Database.Instance.Manufacturers.All(m => m.Id != id)) throw new ArgumentNullException();
        return Database.Instance.Manufacturers.Single(s => s.Id == id);
    }
    
    public ManufacturerEntity GetByName(string name)
    {
        if(name == null) throw new ArgumentNullException();
        if (Database.Instance.Manufacturers.All(m => m.Name != name)) throw new ArgumentNullException(nameof(name));
        return Database.Instance.Manufacturers.Single(m => m.Name == name);
    }
    
    public ManufacturerEntity ReturnOrCreate(ManufacturerEntity manufacturerEntity)
    {
        if (manufacturerEntity == null) throw new ArgumentNullException();
        if (Database.Instance.Manufacturers.Any(m => m.Name == manufacturerEntity.Name))
        {
            return Database.Instance.Manufacturers.Single(m => m.Name == manufacturerEntity.Name);   
        }
        manufacturerEntity.Id = Guid.NewGuid();
        Database.Instance.Manufacturers.Add(manufacturerEntity);
        return Database.Instance.Manufacturers.Single(m => m.Name == manufacturerEntity.Name);
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (Database.Instance.Manufacturers.All(m => m.Id != entity.Id)) throw new ArgumentNullException(nameof(entity));
        var manufacturer = Database.Instance.Manufacturers.Single(m => m.Id == entity.Id);
        manufacturer.Name = entity.Name;
        manufacturer.Description = entity.Description;
        manufacturer.CountryOfOrigin = entity.CountryOfOrigin;
        return manufacturer;
    }

    public void Delete(Guid id)
    {
        if(Database.Instance.Manufacturers.All(m => m.Id != id)) throw new ArgumentException();
        var manufacturer = Database.Instance.Manufacturers.Single(m => m.Id == id);
        var commodities = manufacturer.ListOfCommodities;
        foreach (var c in commodities)
        {
            Database.Instance.Commodities.Remove(c);
        }
        Database.Instance.Manufacturers.Remove(manufacturer);
    }
}