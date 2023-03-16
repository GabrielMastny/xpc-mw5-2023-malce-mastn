namespace App.DAL.Entities;

public record ReviewEntity : EntityBase
{
    public required int Stars { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}