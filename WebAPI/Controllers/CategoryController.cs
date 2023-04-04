using System.Collections.Generic;
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
public class CategoryController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IRepository<CategoryEntity> _repo;
    private readonly IMapper _mapper;
    public CategoryController(ILogger<CategoryController> logger, IRepository<CategoryEntity> repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<CategoryEntity> Get()
    {
        return new List<CategoryEntity>();
    }
    
    [HttpPost(Name = nameof(AddCategory))]
    public ActionResult<string> AddCategory(ApiVersion version, [FromBody] CategoryCreateDTO categoryCreateDto)
    {
        var ent = _mapper.Map<CategoryEntity>(categoryCreateDto);
        var newG = _repo.Create(ent);
#if DEBUG
        return newG.ToString();
#else
            return Ok();
#endif
    }
}