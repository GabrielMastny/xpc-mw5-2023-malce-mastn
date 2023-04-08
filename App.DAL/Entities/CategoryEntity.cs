using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record CategoryEntity : EntityBase, ICategory
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public static CategoryEntity Default()
    {
        return new CategoryEntity()
        {
            Name = string.Empty,
            Description = String.Empty,
            Image = String.Empty,
            Id = Guid.Empty
        };
    }
    
    public static CategoryEntity Default(Guid id)
    {
        CategoryEntity cat = CategoryEntity.Default();
        cat.Id = id;
        return cat;
    }
    
}