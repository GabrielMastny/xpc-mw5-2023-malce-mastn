using System;
namespace App.DAL.Entities;

public abstract record EntityBase : IEntity
{
    public Guid id { get; set; }
}