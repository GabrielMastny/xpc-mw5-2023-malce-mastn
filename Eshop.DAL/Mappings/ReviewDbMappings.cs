using Eshop.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;
using Eshop.DAL.Models;

namespace Eshop.DAL.Mappings;

public class ReviewDbMappings : Profile
{
    public ReviewDbMappings()
    {
        CreateMap<Review, ReviewEntity>().ForMember(dest => dest.RelatedTo, act => act.MapFrom(x => CommodityEntity.Default(x.Id)));
        CreateMap<ReviewEntity, Review>()
            .ForMember(dest => dest.RelatedTo, act => act.MapFrom(rev => rev.RelatedTo.Id));
    }
}