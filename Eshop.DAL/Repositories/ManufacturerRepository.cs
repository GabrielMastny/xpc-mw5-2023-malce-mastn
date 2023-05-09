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
        _db.Manufacturers.Add(_mapper.Map(entity));
        _db.SaveChanges();

        return entity.Id;
    }

    public ManufacturerEntity GetById(Guid id)
    {
        var m = _db.Manufacturers.Single(x => x.Id == id.ToString());
        return _mapper.ReverseMap(m);
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