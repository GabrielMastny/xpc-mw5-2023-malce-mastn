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

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}