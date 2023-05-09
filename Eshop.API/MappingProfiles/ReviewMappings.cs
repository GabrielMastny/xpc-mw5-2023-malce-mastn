using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;

namespace Eshop.API.MappingProfiles;

public class ReviewMappings : Profile
{
    public ReviewMappings()
    {
        CreateMap<ReviewEntity, ReviewDTO>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
        CreateMap<ReviewDTO, ReviewEntity>();
        
        CreateMap<ReviewEntity, ReviewCreateDTO>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
        CreateMap<ReviewCreateDTO, ReviewEntity>();
    }
}