using System.Collections.Generic;
using App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<CategoryEntity> Get()
    {
        return new List<CategoryEntity>();
    }
}