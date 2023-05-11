using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;
using Eshop.API.Interfaces;

namespace Eshop.API.MappingProfiles;

public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<CategoryCreateDTO, CategoryEntity>();
        CreateMap<CategoryEntity, CategoryDTO>().ReverseMap();
    }
}