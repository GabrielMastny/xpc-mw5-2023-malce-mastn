using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;

namespace Eshop.DAL.Repositories;

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
        var man = _db.Manufacturers.Add(entity);
        _db.SaveChanges();

        return man.Entity.Id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        return _mapper.Map<ManufacturerEntity>(_db.Manufacturers.SingleOrDefault(x => x.Id == id));
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        var man = _db.Update(entity);
        _db.SaveChanges();
        
        return _mapper.Map<ManufacturerEntity>(man.Entity);
    }

    public void Delete(Guid id)
    {
        var man = _db.Manufacturers.SingleOrDefault(x => x.Id == id);
        
        if (man == null) throw new ArgumentNullException();;

        _db.Manufacturers.Remove(man);
        _db.SaveChanges();
    }
}