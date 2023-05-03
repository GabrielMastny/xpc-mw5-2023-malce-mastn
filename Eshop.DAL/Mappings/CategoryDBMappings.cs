using App.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Models;

namespace Eshop.DAL.Mappings;

public class CategoryDbMappings : Profile
{
    public CategoryDbMappings()
    {
        CreateMap<Category, CategoryEntity>().ReverseMap();
    }
    
}