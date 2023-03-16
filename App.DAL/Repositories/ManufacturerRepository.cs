using System;
using System.Linq;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    public Guid Create(ManufacturerEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException();

        entity.Id = Guid.NewGuid();
        entity.ListOfCommodities = new List<CommodityEntity>();
        
        Database.Instance.Manufacturers.Add(entity);

        return entity.Id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        return Database.Instance.Manufacturers.Single(s => s.Id == id);
    }
    
    public ManufacturerEntity GetByName(string name)
    {
        return Database.Instance.Manufacturers.Single(s => s.Name == name);
    }
    
    public ManufacturerEntity ReturnOrCreate(string name)
    {
        if (Database.Instance.Manufacturers.Any(s => s.Name == name))
        {
            return Database.Instance.Manufacturers.Single(s => s.Name == name);   
        } 
        else 
        {
            var manufacturer = Create(new ManufacturerEntity()
            {
                Name = name
            });
            return Database.Instance.Manufacturers.Single(s => s.Id == manufacturer);
        }
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}