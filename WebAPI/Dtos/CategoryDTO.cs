using System;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class CategoryDTO : CategoryCreateDTO, ICategory
{
    public Guid Id { get; set; }
}