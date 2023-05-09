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
        if (!_db.Manufacturers.Any(category => entity != null && category.Id == entity.Id.ToString()) || entity == null)
        {
            throw new ArgumentNullException();
        }

        _db.Manufacturers.Update(_mapper.Map(entity));
        _db.SaveChanges();
        return entity;
    }

    public void Delete(Guid id)
    {
        var manufacturer = _db.Manufacturers.Single(manufacturer => manufacturer.Id == id.ToString());
        if (manufacturer == null) throw new ArgumentNullException();
        var commoditiesToRemove = _db.Commodities.Where(commodity => commodity.ManufacturerId == manufacturer.Id);
        foreach (var commodity in commoditiesToRemove)
        {
            _db.Commodities.Remove(commodity);
        }
        _db.Manufacturers.Remove(manufacturer);
        _db.SaveChanges();
    }

}