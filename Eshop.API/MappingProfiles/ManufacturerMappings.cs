using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;

namespace Eshop.API.MappingProfiles;

public class ManufacturerMappings : Profile
{
    public ManufacturerMappings()
    {
        CreateMap<ManufacturerCreateDTO, ManufacturerEntity>().ReverseMap();
        CreateMap<ManufacturerEntity, ManufacturerBriefDTO>();
    }
}