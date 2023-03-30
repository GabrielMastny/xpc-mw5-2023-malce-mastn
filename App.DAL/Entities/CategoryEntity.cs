using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public record CategoryEntity : EntityBase, ICategory
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    
}