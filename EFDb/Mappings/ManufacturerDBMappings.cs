using App.DAL.Entities;
using AutoMapper;
using EFDb.Models;

namespace EFDb.Mappings;

public class ManufacturerDbMappings : Profile
{
    public ManufacturerDbMappings()
    {
        CreateMap<Manufacturer, ManufacturerEntity>().ReverseMap();
    }
}