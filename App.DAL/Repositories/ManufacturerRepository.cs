using System;
using System.Linq;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    public Guid Create(ManufacturerEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException();

        entity.id = Guid.NewGuid();
        entity._listOfCommodities = new List<CommodityEntity>();
        
        Database.Instance.Manufacturers.Add(entity);

        return entity.id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        return Database.Instance.Manufacturers.Single(s => s.id == id);
    }
    
    public ManufacturerEntity GetByName(string name)
    {
        return Database.Instance.Manufacturers.Single(s => s._name == name);
    }
    
    public ManufacturerEntity ReturnOrCreate(string name)
    {
        if (Database.Instance.Manufacturers.Any(s => s._name == name))
        {
            return Database.Instance.Manufacturers.Single(s => s._name == name);   
        } 
        else 
        {
            var manufacturer = Create(new ManufacturerEntity()
            {
                _name = name
            });
            return Database.Instance.Manufacturers.Single(s => s.id == manufacturer);
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