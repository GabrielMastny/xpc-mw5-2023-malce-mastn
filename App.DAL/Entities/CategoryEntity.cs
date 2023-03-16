namespace App.DAL.Entities;

public record CategoryEntity : EntityBase
{
    public required string Name { get; set; }
}