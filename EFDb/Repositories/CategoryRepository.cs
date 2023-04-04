using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;

namespace EFDb.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{
    private readonly EshopContext _db;

    public CategoryRepository(EshopContext db)
    {
        _db = db;
    }
    public Guid Create(CategoryEntity entity)
    {
        var cat = _db.Categories.Add(new Category()
        {
            Description = entity.Description,
            Name = entity.Name,
            Id = entity.Id,
            Image = entity.Image
        });
        _db.SaveChanges();

        return cat.Entity.Id;
    }

    public IEnumerable<CategoryEntity> Get()
    {
        throw new NotImplementedException();
    }

    public CategoryEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}