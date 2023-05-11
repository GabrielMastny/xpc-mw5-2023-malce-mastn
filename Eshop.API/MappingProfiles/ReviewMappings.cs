using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;

namespace Eshop.API.MappingProfiles;

public class ReviewMappings : Profile
{
    public ReviewMappings()
    {
        CreateMap<ReviewEntity, ReviewDTO>().ReverseMap();
        CreateMap<ReviewEntity, ReviewCreateDTO>().ReverseMap();
    }
}