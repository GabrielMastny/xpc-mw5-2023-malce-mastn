using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public class CategoryMapper : IMapper<CategoryEntity, Category>
{
    public Category Map(CategoryEntity categoryEntity)
    {
        return new Category()
        {
            Id = categoryEntity.Id.ToString(),
            Name = categoryEntity.Name,
            Description = categoryEntity.Description,
            Image = categoryEntity.Image
        };
    }

    public CategoryEntity ReverseMap(Category category)
    {
        return new CategoryEntity()
        {
            Id = Guid.Parse(category.Id),
            Name = category.Name,
            Description = category.Description,
            Image = category.Image
        };
    } 
}