using System;
using AutoMapper;
using Eshop.API.Interfaces;

namespace Eshop.API.Dtos;

public class ManufacturerDTO : IManufacturer
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
}