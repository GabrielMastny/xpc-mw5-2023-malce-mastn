﻿using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity> //: IRepository<CategoryEntity>
{

    private readonly EshopContext _db;
    private readonly CategoryMapper _mapper;
    public CategoryRepository(EshopContext eshopContext, CategoryMapper mapper)
    {
        _db = eshopContext;
        _mapper = mapper;
    }
    
    public Guid Create(CategoryEntity entity)
    {
        var category = _mapper.Map(entity);

        _db.Categories.Add(category);
        _db.SaveChanges();

        return entity.Id;
        //throw new NotImplementedException();
    }

    public CategoryEntity GetById(Guid id)
    {
        var c = _db.Categories.Single(x => x.Id.Equals("00e02cde-a825-429f-8c8e-da826f7f2755"));
        return _mapper.ReverseMap(c);
    }

    public CategoryEntity Update(CategoryEntity? entity)
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
    // public CategoryRepository(EshopContext db, IMapper mapper)
    // {
    //     _db = db;
    //     _mapper = mapper;
    // }
    // public Guid Create(CategoryEntity entity)
    // {
    //     var cat = _db.Categories.Add(_mapper.Map<Category>(entity));
    //     _db.SaveChanges();
    //
    //     return cat.Entity.Id;
    // }
    //
    // public CategoryEntity GetById(Guid id)
    // {
    //     var ent = _db.Categories.Where(x => x.Id == id).SingleOrDefault();
    //
    //     if (ent == null) return null;
    //
    //     return _mapper.Map<CategoryEntity>(ent);
    // }
    //
    // public CategoryEntity Update(CategoryEntity? entity)
    // {
    //     if (entity == null )//|| !_db.Categories.Any(x => x.Id == entity.Id))
    //         return null;
    //
    //     var cat = _mapper.Map<Category>(entity);
    //
    //     _db.Categories.Update(cat);
    //     _db.SaveChanges();
    //
    //     return entity;
    // }
    //
    // public void Delete(Guid id)
    // {
    //     var cat = _db.Categories.Where(x => x.Id == id).SingleOrDefault();
    //     
    //     if (cat == null) return;
    //
    //     _db.Categories.Remove(cat);
    //     _db.SaveChanges();
    // }
    
}