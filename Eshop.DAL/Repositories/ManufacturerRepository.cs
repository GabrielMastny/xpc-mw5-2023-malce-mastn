using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.Repositories;

public class ManufacturerRepository : IRepository<ManufacturerEntity>
{
    private readonly EshopContext _db;
    private readonly ManufacturerMapper _mapper;
    public ManufacturerRepository(EshopContext eshopContext, ManufacturerMapper mapper)
    {
        _db = eshopContext;
        _mapper = mapper;
    }
    public Guid Create(ManufacturerEntity entity)
    {
        _db.Add(_mapper.Map(entity));
        _db.SaveChanges();

        return entity.Id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        throw new NotImplementedException();
        //0459fbc6-2b12-489c-9b73-e89a5d543f7c
    }

    public ManufacturerEntity Update(ManufacturerEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
    
    // private readonly EshopContext _db;
    // private readonly IMapper _mapper;
    //
    // public ManufacturerRepository(EshopContext dbContext, IMapper mapper)
    // {
    //     _db = dbContext;
    //     _mapper = mapper;
    // }
    //
    // public Guid Create(ManufacturerEntity entity)
    // {
    //     var man = _db.Manufacturers.Add(_mapper.Map<Manufacturer>(entity));
    //     _db.SaveChanges();
    //
    //     return man.Entity.Id;
    // }
    //
    // public ManufacturerEntity GetById(Guid id)
    // {
    //     return _mapper.Map<ManufacturerEntity>(_db.Manufacturers.SingleOrDefault(x => x.Id == id));
    // }
    //
    // public ManufacturerEntity Update(ManufacturerEntity? entity)
    // {
    //     var man = _db.Update(_mapper.Map<Manufacturer>(entity));
    //     _db.SaveChanges();
    //     
    //     return _mapper.Map<ManufacturerEntity>(man.Entity);
    // }
    //
    // public void Delete(Guid id)
    // {
    //     var man = _db.Manufacturers.SingleOrDefault(x => x.Id == id);
    //     
    //     if (man == null) return;
    //
    //     _db.Manufacturers.Remove(man);
    //     _db.SaveChanges();
    // }
    
}