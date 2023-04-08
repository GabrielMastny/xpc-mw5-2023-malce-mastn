using App.DAL.Entities;
using AutoMapper;
using EFDb.Models;

namespace EFDb.Mappings;

public class CommodityDbMappings : Profile
{
    public CommodityDbMappings()
    {
        CreateMap<CommodityEntity, Commodity>();

        CreateMap<Commodity, CommodityEntity>();
    }
}