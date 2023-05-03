using Eshop.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using Eshop.DAL.Context;
using Eshop.DAL.Models;

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
        var cat = _db.Categories.Add(_mapper.Map<Category>(entity));
        _db.SaveChanges();

        return cat.Entity.Id;
    }

    public CategoryEntity GetById(Guid id)
    {
        var ent = _db.Categories.Where(x => x.Id == id).SingleOrDefault();

        if (ent == null) return null;

        return _mapper.Map<CategoryEntity>(ent);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (entity == null )//|| !_db.Categories.Any(x => x.Id == entity.Id))
            return null;

        var cat = _mapper.Map<Category>(entity);

        _db.Categories.Update(cat);
        _db.SaveChanges();

        return entity;
    }

    public void Delete(Guid id)
    {
        var cat = _db.Categories.Where(x => x.Id == id).SingleOrDefault();
        
        if (cat == null) return;

        _db.Categories.Remove(cat);
        _db.SaveChanges();
    }
}