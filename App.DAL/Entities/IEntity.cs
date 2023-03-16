using System;
namespace App.DAL.Entities;

public interface IEntity
{
    Guid Id { get; set; }
}