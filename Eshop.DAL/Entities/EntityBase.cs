namespace Eshop.DAL.Entities;

public record EntityBase() : IEntity
{
    public Guid Id { get; set; }
}