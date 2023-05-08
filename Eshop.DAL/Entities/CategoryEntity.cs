namespace Eshop.DAL.Entities;

//[Table("Category")]
public record CategoryEntity : EntityBase
{
    //[Key]
    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}