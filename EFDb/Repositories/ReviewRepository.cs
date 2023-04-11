using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Models;

namespace EFDb.Repositories;

public class ReviewRepository : IRepository<ReviewEntity>
{
    private readonly EshopContext _db;
    private readonly IMapper _mapper;
    
    public ReviewRepository(EshopContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public Guid Create(ReviewEntity entity)
    {
        var entry = _db.Reviews.Add(_mapper.Map<Review>(entity));
        _db.SaveChanges();
        
        return entry.Entity.Id;
    }

    public IEnumerable<ReviewEntity> Get()
    {
        return _db.Reviews.Select(x => _mapper.Map<ReviewEntity>(x));
    }

    public ReviewEntity GetById(Guid id)
    {
        var rev = _db.Reviews.SingleOrDefault(x => x.Id == id);

        return rev == null ? ReviewEntity.Default() : _mapper.Map<ReviewEntity>(rev);
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        var rev = _db.Update(_mapper.Map<Review>(entity));
        _db.SaveChanges();

        return _mapper.Map<ReviewEntity>(rev.Entity);
    }

    public void Delete(Guid id)
    {
        var rev = _db.Reviews.SingleOrDefault(x => x.Id == id);
        
        if (rev == null) return;

        _db.Reviews.Remove(rev);
        _db.SaveChanges();
    }
}