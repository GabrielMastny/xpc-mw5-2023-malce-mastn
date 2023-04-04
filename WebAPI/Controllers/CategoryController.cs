using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public IEnumerable<CategoryDTO> Get()
    {
        return _repo.Get().Select(x => _mapper.Map<CategoryDTO>(x));
    }
    
    [HttpPost(Name = nameof(AddCategory))]
    public ActionResult<string> AddCategory(ApiVersion version, [FromBody] CategoryCreateDTO categoryCreateDto)
    {
        var newG = _repo.Create(_mapper.Map<CategoryEntity>(categoryCreateDto));
        
#if DEBUG
        return newG.ToString(); 
#else
        return (Guid.Empty == newG) ? new BadRequestResult() : new OkResult();
#endif
    }
    
    [HttpGet]
    [Route("{id:Guid}", Name = nameof(GetSingleCategory))]
    public ActionResult<CategoryDTO> GetSingleCategory(ApiVersion version, Guid id)
    {
       var cat =  _repo.GetById(id);
       
       if (Guid.Empty == cat.Id)
       {
           return new NotFoundResult();
       }
       
       return _mapper.Map<CategoryDTO>(cat);
    }

    [HttpPut]
    [Route("{id:Guid}", Name = nameof(UpdateCategory))]
    public ActionResult<CategoryDTO> UpdateCategory(ApiVersion version, Guid id, [FromBody] CategoryDTO categoryDto)
    {
        if (categoryDto == null)
            return new BadRequestResult();
        
        var cat = _repo.Update(_mapper.Map<CategoryEntity>(categoryDto));

        if (Guid.Empty == cat.Id)
            return new NotFoundResult();

        return _mapper.Map<CategoryDTO>(cat);
    }

    [HttpDelete]
    [Route("{id:Guid}", Name = nameof(RemoveCategory))]
    public ActionResult RemoveCategory(Guid id)
    {
        _repo.Delete(id);

        return new OkResult();
    }
}