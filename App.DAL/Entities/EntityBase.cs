using CommonDbProperties.Interfaces.Entities;

namespace App.DAL.Entities;

public abstract record EntityBase : IWithId
{
    public Guid Id { get; set; }
}