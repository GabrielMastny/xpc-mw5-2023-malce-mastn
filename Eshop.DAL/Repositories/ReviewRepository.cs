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
        var review= _db.Reviews.SingleOrDefault(x => x.Id == id);

        return review;
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        var review= _db.Update(entity);
        _db.SaveChanges();

        return _mapper.Map<ReviewEntity>(review.Entity);
    }

    public void Delete(Guid id)
    {
        var review= _db.Reviews.SingleOrDefault(x => x.Id == id);
        
        if (review== null) throw new ArgumentNullException();;

        _db.Reviews.Remove(review);
        _db.SaveChanges();
    }
}