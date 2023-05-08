namespace Eshop.DAL.Entities;

//[Table("Category")]
public record CategoryEntity : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}