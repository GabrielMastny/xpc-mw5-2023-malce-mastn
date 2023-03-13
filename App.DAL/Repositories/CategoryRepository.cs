using System;
using System.ComponentModel.Design;
using System.Linq;
using App.DAL.Entities;

namespace App.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{
    public Guid Create(CategoryEntity? entity)
    {
        if (entity is null) throw new ArgumentNullException();

        // if (Database.Instance.Categories.Contains(entity) != null)
        // {
        //     return new Guid();// Database.Instance.Categories.;
        // }
        // else 
        // {
        //     entity.id = new Guid();
        //     
        //     Database.Instance.Categories.Add(entity);
        //     
        //     return entity.id;
        // }
        
        entity.id = Guid.NewGuid();
        
        Database.Instance.Categories.Add(entity);

        return entity.id;

    }

    public CategoryEntity ReturnOrCreate(string name)
    {
        if (Database.Instance.Categories.Any(s => s._name == name))
        {
            return Database.Instance.Categories.Single(s => s._name == name);   
        } 
        else 
        {
            var category = Create(new CategoryEntity()
            {
                _name = name
            });
            return Database.Instance.Categories.Single(s => s.id == category);
        }
    }

    public CategoryEntity GetById(Guid id)
    {
        return Database.Instance.Categories.Single(s => s.id == id);
    }
    
    public CategoryEntity GetByName(string name)
    {
        return Database.Instance.Categories.Single(s => s._name == name);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        var existingCategory = Database.Instance.Categories.Single(s => s.id == entity.id);
        existingCategory._name = entity._name;
        return existingCategory;
    }

    public void Delete(Guid id)
    {
        var category = Database.Instance.Categories.Single(s => s.id == id);
        Database.Instance.Categories.Remove(category);
    }
}