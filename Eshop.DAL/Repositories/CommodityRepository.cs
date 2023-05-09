using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    
    private readonly EshopContext _db;
    private readonly CommodityMapper _mapper;
    public CommodityRepository(EshopContext eshopContext, CommodityMapper mapper)
    {
        _db = eshopContext;
        _mapper = mapper;
    }
    
    public Guid Create(CommodityEntity entity)
    {
        _db.Commodities.Add(_mapper.Map(entity));
        _db.SaveChanges();
        return entity.Id;
    }

    public CommodityEntity GetById(Guid id)
    {
        var c = _db.Commodities.Single(x => x.Id == id.ToString());

        c.Manufacturer = _db.Manufacturers.Single(m => m.Id == c.ManufacturerId);

        c.Category = _db.Categories.Single(m => m.Id == c.CategoryId);

        var reviews = _db.Reviews.Where(r => r.CommodityId == id.ToString());

        foreach (var r in reviews)
        {
            c.Reviews.Add(r);
        }

        return _mapper.ReverseMap(c);
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        if (!_db.Commodities.Any(commodity => entity != null && commodity.Id == entity.Id.ToString()) || entity == null)
        {
            throw new ArgumentNullException();
        }

        _db.Commodities.Update(_mapper.Map(entity));
        _db.SaveChanges();
        return entity;
    }

    public void Delete(Guid id)
    {
        var commodity = _db.Commodities.Single(commodity => commodity.Id == id.ToString());
        if (commodity == null) throw new ArgumentNullException();
        _db.Commodities.Remove(commodity);
        _db.SaveChanges();
    }

}