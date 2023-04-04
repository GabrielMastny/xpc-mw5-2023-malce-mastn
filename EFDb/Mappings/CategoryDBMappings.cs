using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;
using EFDb.Models;

namespace EFDb.Mappings;

public class CategoryDBMappings : Profile
{
    public CategoryDBMappings()
    {
        CreateMap<ICategory, CategoryEntity>();
        CreateMap<CategoryEntity, Category>();
    }
    
}