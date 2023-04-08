using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;

namespace App.DAL.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    public Guid Create(ManufacturerEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException();

        entity.Id = Guid.NewGuid();
        //entity.ListOfCommodities = new List<CommodityEntity>();
        
        Database.Instance.Manufacturers.Add(entity);

        return entity.Id;
    }
    
    public IEnumerable<ManufacturerEntity> Get()
    {
        return Database.Instance.Manufacturers;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        return Database.Instance.Manufacturers.Single(s => s.Id == id);
    }
    
    public ManufacturerEntity GetByName(string name)
    {
        if(name == null) throw new ArgumentNullException();
        return Database.Instance.Manufacturers.Single(s => s.Name == name);
    }
    
    public ManufacturerEntity ReturnOrCreate(ManufacturerEntity manufacturerEntity)
    {
        
        if (manufacturerEntity is null) throw new ArgumentNullException();
        
        if (Database.Instance.Manufacturers.Any(s => s.Name == manufacturerEntity.Name))
        {
            return Database.Instance.Manufacturers.Single(s => s.Name == manufacturerEntity.Name);   
        }

        manufacturerEntity.Id = Guid.NewGuid();
        //manufacturerEntity.ListOfCommodities = new List<CommodityEntity>();
        
        Database.Instance.Manufacturers.Add(manufacturerEntity);
            
        return Database.Instance.Manufacturers.Single(s => s.Name == manufacturerEntity.Name);
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        var manufacturer = Database.Instance.Manufacturers.Single(s => s.Id == entity.Id);
        manufacturer.Name = entity.Name;
        manufacturer.Description = entity.Description;
        manufacturer.CountryOfOrigin = entity.CountryOfOrigin;
        return manufacturer;
    }

    public void Delete(Guid id)
    {
        if(!Database.Instance.Manufacturers.Any(c => c.Id == id)) throw new ArgumentException();
        
        var manufacturer = Database.Instance.Manufacturers.Single(s => s.Id == id);
        //Database.Instance.Manufacturers.Single(m => m == commodity.Manufacturer).ListOfCommodities.Remove(commodity);
        Database.Instance.Manufacturers.Remove(manufacturer);
    }
}