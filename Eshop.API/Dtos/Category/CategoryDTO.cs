using System;
using Eshop.API.Interfaces;

namespace Eshop.API.Dtos;

public record CategoryDTO : ICategory
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}