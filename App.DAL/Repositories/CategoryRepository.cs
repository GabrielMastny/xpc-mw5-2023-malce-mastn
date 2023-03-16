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

        entity.Id = Guid.NewGuid();
        
        Database.Instance.Categories.Add(entity);

        return entity.Id;

    }

    public CategoryEntity ReturnOrCreate(string name)
    {
        if (Database.Instance.Categories.Any(s => s.Name == name))
        {
            return Database.Instance.Categories.Single(s => s.Name == name);   
        } 
        else 
        {
            var category = Create(new CategoryEntity()
            {
                Name = name
            });
            return Database.Instance.Categories.Single(s => s.Id == category);
        }
    }

    public CategoryEntity GetById(Guid id)
    {
        return Database.Instance.Categories.Single(s => s.Id == id);
    }
    
    public CategoryEntity GetByName(string name)
    {
        return Database.Instance.Categories.Single(s => s.Name == name);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        
        var existingCategory = Database.Instance.Categories.Single(s => s.Id == entity.Id);
        existingCategory.Name = entity.Name;
        return existingCategory;
    }

    public void Delete(Guid id)
    {
        var category = Database.Instance.Categories.Single(s => s.Id == id);
        Database.Instance.Categories.Remove(category);
    }
}