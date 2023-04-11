using System;
using AutoMapper;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class ManufacturerDTO : ManufacturerCreateDTO, IManufacturer
{
    public Guid Id { get; set; }
}