using App.DAL.Entities;
using AutoMapper;
using EFDb.Models;

namespace EFDb.Mappings;

public class CategoryDbMappings : Profile
{
    public CategoryDbMappings()
    {
        CreateMap<Category, CategoryEntity>().ReverseMap();
    }
    
}