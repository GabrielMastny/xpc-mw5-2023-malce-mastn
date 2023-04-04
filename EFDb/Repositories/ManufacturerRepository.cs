using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;

namespace EFDb.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    private readonly EshopContext _db;
    
    public ManufacturerRepository(EshopContext dbContext)
    {
        _db = dbContext;
    }
    
    public Guid Create(ManufacturerEntity entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ManufacturerEntity> Get()
    {
        throw new NotImplementedException();
    }

    public ManufacturerEntity GetById(Guid id)
    {
        throw new NotImplementedException();
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