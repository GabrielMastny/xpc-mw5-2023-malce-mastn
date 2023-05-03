using Eshop.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;
using WebAPI.Dtos;

namespace WebAPI.MappingProfiles;

public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<CategoryCreateDTO, CategoryEntity>();
        CreateMap<ICategory, CategoryDTO>();
    }
}