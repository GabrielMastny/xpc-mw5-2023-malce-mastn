using Eshop.DAL.Entities;
using AutoMapper;
using WebAPI.Dtos;

namespace WebAPI.MappingProfiles;

public class ManufacturerMappings : Profile
{
    public ManufacturerMappings()
    {
        CreateMap<ManufacturerCreateDTO, ManufacturerEntity>().ReverseMap();
        CreateMap<ManufacturerEntity, ManufacturerBriefDTO>();
    }
}