using System;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{
    public Guid Create(CategoryEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException();

        if (Database.Instance.Categories.Contains(entity) != null)
        {
            return new Guid();// Database.Instance.Categories.;
        }
        else 
        {
            entity.id = new Guid();
            
            Database.Instance.Categories.Add(entity);
            
            return entity.id;
        }

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