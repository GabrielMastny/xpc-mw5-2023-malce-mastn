﻿using Eshop.DAL.Entities;
using Eshop.DAL.Mappers;

namespace Eshop.DAL.Repositories;

public class ReviewRepository : IRepository<ReviewEntity>
{
    private readonly EshopContext _db;
    private readonly ReviewMapper _mapper;
    public ReviewRepository(EshopContext eshopContext, ReviewMapper mapper)
    {
        _db = eshopContext;
        _mapper = mapper;
    }
    public Guid Create(ReviewEntity entity)
    {
        _db.Reviews.Add(_mapper.Map(entity));
        _db.SaveChanges();

        return entity.Id;
    }

    public ReviewEntity GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public ReviewEntity Update(ReviewEntity? entity)
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
    // public ReviewRepository(EshopContext db, IMapper mapper)
    // {
    //     _db = db;
    //     _mapper = mapper;
    // }
    //
    // public Guid Create(ReviewEntity entity)
    // {
    //     var entry = _db.Reviews.Add(_mapper.Map<Review>(entity));
    //     _db.SaveChanges();
    //     
    //     return entry.Entity.Id;
    // }
    //
    // public ReviewEntity GetById(Guid id)
    // {
    //     var rev = _db.Reviews.SingleOrDefault(x => x.Id == id);
    //
    //     return rev == null ? ReviewEntity.Default() : _mapper.Map<ReviewEntity>(rev);
    // }
    //
    // public ReviewEntity Update(ReviewEntity? entity)
    // {
    //     var rev = _db.Update(_mapper.Map<Review>(entity));
    //     _db.SaveChanges();
    //
    //     return _mapper.Map<ReviewEntity>(rev.Entity);
    // }
    //
    // public void Delete(Guid id)
    // {
    //     var rev = _db.Reviews.SingleOrDefault(x => x.Id == id);
    //     
    //     if (rev == null) return;
    //
    //     _db.Reviews.Remove(rev);
    //     _db.SaveChanges();
    // }
    
}