using System.Linq.Expressions;
using App.DAL.Entities;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;

namespace EFDb.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    private readonly EshopContext _db;
    
    public CommodityRepository(EshopContext dbContext)
    {
        _db = dbContext;
    }

    public Guid Create(CommodityEntity entity)
    {
        
        if (!_db.Categories.Any(x => x.Id == entity.Category.Id))
            return Guid.Empty;
        
        if (_db.Manufacturers.Any(x => x.Id == entity.Manufacturer.Id))
            return Guid.Empty;
        
        Guid newComId = _db.Comodities.Add(new Commodity()
        {
            Description = entity.Description,
            Image = entity.Image,
            Name = entity.Name,
            Price = entity.Price,
            Weight = entity.Weight,
            CategoryId = entity.Category.Id,
            ManufacturerId = entity.Manufacturer.Id,
            NumberOfPiecesInStock = entity.NumberOfPiecesInStock
        }).Entity.Id;
        _db.SaveChanges();
        return newComId;
    }

    public IEnumerable<CommodityEntity> Get()
    {
       return _db.Comodities.Select(x => new CommodityEntity()
        {
            Description = x.Description,
            Image = x.Image,
            Name = x.Name,
            Price = x.Price,
            Weight = x.Weight,
            Category = new CategoryEntity() { Description = "", Id = x.CategoryId, Image = "", Name = "" },
            Id = x.Id,
            Manufacturer = new ManufacturerEntity()
                { Description = "", Id = x.ManufacturerId, Image = "", Name = "", CountryOfOrigin = "" },
            NumberOfPiecesInStock = x.NumberOfPiecesInStock,

        }).ToList();
    }

    public CommodityEntity GetById(Guid id)
    {
        return _db.Comodities.Where(x => x.Id == id).Select(y => new CommodityEntity()
        {
            Description = y.Description,
            Image = y.Image,
            Name = y.Name,
            Price = y.Price,
            Weight = y.Weight,
            Category = new CategoryEntity()
            {
                Description = "",
                Id = y.CategoryId,
                Image = "",
                Name = ""
            },
            Id = y.Id,
            Manufacturer = new ManufacturerEntity()
            {
                Description = "",
                Id = y.ManufacturerId,
                Image = "",
                Name = "",
                CountryOfOrigin = ""
            },
            NumberOfPiecesInStock = y.NumberOfPiecesInStock,

        }).Single();
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        if (entity == null)
            return null;

        var qr = _db.Comodities.Where(x => x.Id == entity.Id).Single();
        return entity;
    }

    public void Delete(Guid id)
    {
        var ent = _db.Comodities.Where(x => x.Id == id).SingleOrDefault();
        if (ent == null) return;

        _db.Comodities.Remove(ent);
    }
}