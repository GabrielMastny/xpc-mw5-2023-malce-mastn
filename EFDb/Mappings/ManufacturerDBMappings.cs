using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;
using EFDb.Models;

namespace EFDb.Mappings;

public class ManufacturerDBMappings : Profile
{
    public ManufacturerDBMappings()
    {
        CreateMap<IManufacturer, ManufacturerEntity>();
    }
}