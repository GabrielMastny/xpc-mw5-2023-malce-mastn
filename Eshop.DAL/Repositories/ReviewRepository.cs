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

}