using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;
using EFDb.Models;

namespace EFDb.Mappings;

public class ReviewDbMappings : Profile
{
    public ReviewDbMappings()
    {
        CreateMap<Review, ReviewEntity>().ForMember(dest => dest.RelatedTo, act => act.MapFrom(x => CommodityEntity.Default(x.Id)));
        CreateMap<ReviewEntity, Review>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
    }
}