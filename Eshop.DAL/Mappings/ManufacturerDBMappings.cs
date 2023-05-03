using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.DAL.Models;

namespace Eshop.DAL.Mappings;

public class ManufacturerDbMappings : Profile
{
    public ManufacturerDbMappings()
    {
        CreateMap<Manufacturer, ManufacturerEntity>().ReverseMap();
    }
}