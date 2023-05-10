using System;
using System.Collections.Generic;
using System.Linq;
using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.QueryObjects.Filters;
using Eshop.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eshop.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CategoryController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IRepository<CategoryEntity> _repo;
    private readonly IMapper _mapper;
    private readonly GetCategoriesByCategoryFilterQuery _query;
    public CategoryController(ILogger<CategoryController> logger, IRepository<CategoryEntity> repo, IMapper mapper, GetCategoriesByCategoryFilterQuery query)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
        _query = query;
    }

    [HttpGet(Name = "GetCategories")]
    public IEnumerable<CategoryDTO> Get()
    {
        //return _repo.Get().Select(x => _mapper.Map<CategoryDTO>(x));
        return null;
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

    [HttpPost]
    [Route($"[action]")]
    public ActionResult<List<CategoryEntity>> FilterCategory(ApiVersion version, CategoryFilter categoryFilter)
    {
        var results = _query.Execute(categoryFilter);
        List<CategoryEntity> names = new List<CategoryEntity>();
        foreach (var r in results)
        {
            names.Add(r);
        }
        return names; 
    }
}