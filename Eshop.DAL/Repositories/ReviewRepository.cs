using Eshop.DAL.Entities;
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
        var r = _db.Reviews.Single(review => review.Id == id.ToString());
        return _mapper.ReverseMap(r);
    }

    public ReviewEntity Update(ReviewEntity? entity)
    {
        if (!_db.Reviews.Any(review => entity != null && review.Id == entity.Id.ToString()) || entity == null)
        {
            throw new ArgumentNullException();
        }
        _db.Reviews.Update(_mapper.Map(entity));
        _db.SaveChanges();
        return entity;
    }

    public void Delete(Guid id)
    {
        var review = _db.Reviews.Single(review => review.Id == id.ToString());
        if (review == null) throw new ArgumentNullException();
        _db.Reviews.Remove(review);
        _db.SaveChanges();
    }

}