using App.DAL.Entities;
using AutoMapper;
using WebAPI.Dtos;

namespace WebAPI.MappingProfiles;

public class CategoryMappings : Profile
{
    public CategoryMappings()
    {
        CreateMap<CategoryCreateDTO, CategoryEntity>().ReverseMap();
    }
}