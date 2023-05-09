using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;

namespace Eshop.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{
    private readonly EshopContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public Guid Create(CategoryEntity entity)
    {
        var cat = _db.Categories.Add(entity);
        _db.SaveChanges();

        return cat.Entity.Id;
    }

    public CategoryEntity GetById(Guid id)
    {
        var ent = _db.Categories.Where(category => category.Id == id).SingleOrDefault();

        if (ent == null) return null;

        return _mapper.Map<CategoryEntity>(ent);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (entity == null || !_db.Categories.Any(category => category.Id == entity.Id)) return null;

        _db.Categories.Update(entity);
        _db.SaveChanges();

        return entity;
    }

    public void Delete(Guid id)
    {
        var category = _db.Categories.Where(category => category.Id == id).SingleOrDefault();
        
        if (category == null) return;

        _db.Categories.Remove(category);
        _db.SaveChanges();
    }
}