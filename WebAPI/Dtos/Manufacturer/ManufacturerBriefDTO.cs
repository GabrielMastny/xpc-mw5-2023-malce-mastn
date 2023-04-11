using System;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class ManufacturerBriefDTO : ManufacturerCreateDTO, IManufacturer
{
    public Guid Id { get; set; }
    
    public int CommoditiesCount { get; set; }
}