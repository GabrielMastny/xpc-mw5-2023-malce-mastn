using App.DAL.Entities;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;

namespace EFDb.Repositories;

public class CommodityRepository : IRepository<CommodityEntity>
{
    private EshopContext _db;
    
    public CommodityRepository(EshopContext dbContext)
    {
        _db = dbContext;
    }


    public Guid Create(CommodityEntity entity)
    {
        Guid categoryId = Guid.Empty;

        if (_db.Categories.Any(x => x.Id == entity.Category.Id))
            categoryId = _db.Categories.Where(x => x.Id == entity.Category.Id)
                .Select(y => y.Id)
                .Single();
        else
            categoryId = (_db.Categories.Add(new Category()
            {
                Name = entity.Category.Name,
                Description = entity.Category.Description,
                Image = entity.Category.Image
            })).Entity.Id;
        
        Guid manufacturerId = Guid.Empty;
        
        if (_db.Manufacturers.Any(x => x.Id == entity.Manufacturer.Id))
            manufacturerId = _db.Manufacturers.Where(x => x.Id == entity.Manufacturer.Id)
                .Select(y => y.Id)
                .Single();
        else
            manufacturerId = (_db.Manufacturers.Add(new Manufacturer()
            {
                Name = entity.Category.Name,
                Description = entity.Category.Description,
                Image = entity.Category.Image
            })).Entity.Id;
        
        
        Commodity comm = null;
        Guid newComId = _db.Comodities.Add(new Commodity()
        {
            Description = entity.Description,
            Image = entity.Image,
            Name = entity.Name,
            Price = entity.Price,
            Weight = entity.Weight,
            CategoryId = categoryId,
            ManufacturerId = manufacturerId,
            NumberOfPiecesInStock = entity.NumberOfPiecesInStock
        }).Entity.Id;
        _db.SaveChanges();
        return newComId;
    }

    public IEnumerable<CommodityEntity> Get()
    {
        throw new NotImplementedException();
    }

    public CommodityEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public CommodityEntity Update(CommodityEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}