using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;

namespace Eshop.DAL.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    private readonly EshopContext _db;

    public CommodityRepository(EshopContext dbContext)
    {
        _db = dbContext;
    }

    public Guid Create(CommodityEntity entity)
    {
        if (_db.Comodities.Any(x => x.Name == entity.Name))
        {
            return Guid.Empty;
        }
        else
        {
            var commodity = _db.Comodities.Add(new CommodityEntity()
            {
                Name = entity.Name,
                Description = entity.Description,
                Image = entity.Image,
                Category = entity.Category,
                Manufacturer = entity.Manufacturer,
                NumberOfPiecesInStock = entity.NumberOfPiecesInStock,
                Price = entity.Price,
                Weight = entity.Weight
            });   
        }

        _db.SaveChanges();
        return entity.Id;
    }

    public CommodityEntity GetById(Guid id)
    {
        return _db.Comodities.Where(x => x.Id == id).Select(y => new CommodityEntity
        {
            Description = y.Description,
            Image = y.Image,
            Name = y.Name,
            Price = y.Price,
            Weight = y.Weight,
            Category = new CategoryEntity
            {
                Description = y.Category.Description,
                Id = y.Category.Id,
                Image = y.Category.Description,
                Name = y.Category.Name
            },
            Id = y.Id,
            Manufacturer = new ManufacturerEntity
            {
                Description = y.Manufacturer.Description,
                Id = y.Manufacturer.Id,
                Image = y.Manufacturer.Image,
                Name = y.Manufacturer.Name,
                CountryOfOrigin = y.Manufacturer.CountryOfOrigin
            },
            NumberOfPiecesInStock = y.NumberOfPiecesInStock,

        }).Single();
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        if (entity == null)
            return null;

        var qr = _db.Comodities.Update(entity);
        return entity;
    }

    public void Delete(Guid id)
    {
        var entity = _db.Comodities.Where(x => x.Id == id).SingleOrDefault();
        if (entity == null) throw new ArgumentNullException();

        _db.Comodities.Remove(entity);
        _db.SaveChanges();
    }
}