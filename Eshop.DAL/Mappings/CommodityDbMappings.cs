using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Models;

namespace Eshop.DAL.Mappings;

public class CommodityDbMappings : Profile
{
    public CommodityDbMappings()
    {
        CreateMap<CommodityEntity, Commodity>();

        CreateMap<Commodity, CommodityEntity>();
    }
}