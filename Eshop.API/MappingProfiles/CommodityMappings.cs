using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;

namespace Eshop.API.MappingProfiles;

public class CommodityMappings :Profile
{
    public CommodityMappings()
    {
        
        
        CreateMap<CommodityEntity, CommodityCreateDto>().ReverseMap();
        CreateMap<CommodityEntity, CommodityDto>().ReverseMap();

    }
}