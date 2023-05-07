﻿using Eshop.DAL.Entities;
using AutoMapper;
using WebAPI.Dtos;

namespace WebAPI.MappingProfiles;

public class CommodityMappings :Profile
{
    public CommodityMappings()
    {
        
        
        CreateMap<CommodityEntity, CommodityCreateDto>()
            .ForMember(dto => dto.CategoryId, act => act.MapFrom((ent => ent.Category.Id)))
            .ForMember(dto => dto.ManufacturerId, act => act.MapFrom(ent => ent.Manufacturer.Id))
            .ReverseMap();

        CreateMap<CommodityEntity, CommodityDto>().ReverseMap();

    }
}