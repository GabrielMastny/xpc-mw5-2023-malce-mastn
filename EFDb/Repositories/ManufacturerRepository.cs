using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;

namespace EFDb.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public ManufacturerRepository(EshopContext dbContext, IMapper mapper)
    {
        _db = dbContext;
        _mapper = mapper;
    }
    
    public Guid Create(ManufacturerEntity entity)
    {
        var cat = _db.Manufacturers.Add(_mapper.Map<Manufacturer>(entity));
        _db.SaveChanges();

        return cat.Entity.Id;
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