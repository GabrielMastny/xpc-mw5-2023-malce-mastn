namespace App.DAL.Entities;

public record CategoryEntity : EntityBase
{
    public required string _name { get; set; }
}