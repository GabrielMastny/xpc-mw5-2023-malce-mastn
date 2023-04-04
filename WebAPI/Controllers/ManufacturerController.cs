﻿using System.Collections.Generic;
using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Dtos;

namespace WebAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ManufacturerController
{
    private readonly ILogger<ManufacturerController> _logger;
    private readonly IRepository<ManufacturerEntity> _repo;
    private readonly IMapper _mapper;
    public ManufacturerController(ILogger<ManufacturerController> logger, IRepository<ManufacturerEntity> repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ManufacturerEntity> Get()
    {
        return new List<ManufacturerEntity>();
    }
    
    [HttpPost(Name = nameof(AddManufacturer))]
    public ActionResult<string> AddManufacturer(ApiVersion version, [FromBody] ManufacturerCreateDTO manufacturerCreateDto)
    {
        var ent = _mapper.Map<ManufacturerEntity>(manufacturerCreateDto);
        var newG = _repo.Create(ent);
#if DEBUG
        return newG.ToString();
#else
            return Ok();
#endif
    }
}