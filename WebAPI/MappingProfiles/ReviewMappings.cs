using App.DAL.Entities;
using AutoMapper;
using WebAPI.Dtos;

namespace WebAPI.MappingProfiles;

public class ReviewMappings : Profile
{
    public ReviewMappings()
    {
        CreateMap<ReviewEntity, ReviewDTO>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
        CreateMap<ReviewDTO, ReviewEntity>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => CommodityEntity.Default(rev.RelatedTo)));
        
        CreateMap<ReviewEntity, ReviewCreateDTO>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
        CreateMap<ReviewCreateDTO, ReviewEntity>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => CommodityEntity.Default(rev.RelatedTo)));
    }
}