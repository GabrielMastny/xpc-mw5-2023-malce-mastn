using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Context;

namespace Eshop.DAL.Repositories;

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
        var entry = _db.Reviews.Add(entity);
        _db.SaveChanges();
        
        return entry.Entity.Id;
    }

    public ReviewEntity GetById(Guid id)
    {
        var rev = _db.Reviews.SingleOrDefault(x => x.Id == id);

        return rev;
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        var rev = _db.Update(entity);
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