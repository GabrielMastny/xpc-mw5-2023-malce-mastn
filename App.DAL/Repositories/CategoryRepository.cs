using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;

namespace App.DAL.Repositories;

public class CategoryRepository : IRepository<CategoryEntity>
{
    public Guid Create(CategoryEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException();

        entity.Id = Guid.NewGuid();
        
        Database.Instance.Categories.Add(entity);

        return entity.Id;
    }
    
    public IEnumerable<CategoryEntity> Get()
    {
        return Database.Instance.Categories;
    }

    public CategoryEntity ReturnOrCreate(CategoryEntity entity)
    {
        if (entity == null) throw new ArgumentNullException();
        if (Database.Instance.Categories.Any(c => c.Name == entity.Name))
        {
            return Database.Instance.Categories.Single(c => c.Name == entity.Name);   
        }
        var category = Create(entity);
        return Database.Instance.Categories.Single(c => c.Id == category);
    }

    public CategoryEntity GetById(Guid id)
    {
        if (Database.Instance.Categories.All(c => c.Id != id)) throw new ArgumentNullException();
        return Database.Instance.Categories.Single(c => c.Id == id);
    }
    
    public CategoryEntity GetByName(string name)
    {
        if(name == null) throw new ArgumentNullException();
        if (Database.Instance.Categories.All(c => c.Name != name)) throw new ArgumentNullException(nameof(name));
        return Database.Instance.Categories.Single(c => c.Name == name);
    }

    public CategoryEntity Update(CategoryEntity? entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        if (Database.Instance.Categories.All(c => c.Id != entity.Id)) throw new ArgumentNullException(nameof(entity));
        var existingCategory = Database.Instance.Categories.Single(c => c.Id == entity.Id);
        existingCategory.Name = entity.Name;
        return existingCategory;
    }

    public void Delete(Guid id)
    {
        if(Database.Instance.Categories.All(c => c.Id != id)) throw new ArgumentException();
        var category = Database.Instance.Categories.Single(c => c.Id == id);
        Database.Instance.Categories.Remove(category);
    }
}