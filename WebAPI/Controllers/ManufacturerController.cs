using System.Collections.Generic;
using App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ManufacturerController
{
    private readonly ILogger<ManufacturerController> _logger;

    public ManufacturerController(ILogger<ManufacturerController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ManufacturerEntity> Get()
    {
        return new List<ManufacturerEntity>();
    }
}