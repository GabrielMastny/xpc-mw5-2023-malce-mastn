using System;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class CategoryCreateDTO
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}