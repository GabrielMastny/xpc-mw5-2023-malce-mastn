using System;
namespace App.DAL.Entities;

public abstract record EntityBase : IEntity
{
    public Guid Id { get; set; }
}