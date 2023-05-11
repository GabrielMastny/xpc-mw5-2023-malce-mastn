using System;
using Eshop.API.Interfaces;

namespace Eshop.API.Dtos;

public class ManufacturerBriefDTO : ManufacturerCreateDTO, IManufacturer
{
    public Guid Id { get; set; }
}