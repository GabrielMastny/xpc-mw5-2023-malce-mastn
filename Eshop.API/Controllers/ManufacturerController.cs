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
public class ManufacturerController
{
    private readonly ILogger<ManufacturerController> _logger;
    private readonly IRepository<ManufacturerEntity> _repo;
    private readonly IMapper _mapper;
    private readonly GetManufacturersByManufacturerDataFilterQuery _query;
    public ManufacturerController(ILogger<ManufacturerController> logger, IRepository<ManufacturerEntity> repo, IMapper mapper, GetManufacturersByManufacturerDataFilterQuery query)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
        _query = query;
    }

    [HttpGet(Name = "GetManufacturers")]
    public IEnumerable<ManufacturerDTO> Get()
    {
        //return _repo.Get().Select(x => _mapper.Map<ManufacturerDTO>(x));
        return null;
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

    [HttpPost]
    [Route($"[action]")]
    public ActionResult<List<ManufacturerEntity>> FilterManufacturer(ApiVersion version, ManufacturerDataFilter manufacturerDataFilter)
    {
        var results = _query.Execute(manufacturerDataFilter);
        List<ManufacturerEntity> names = new List<ManufacturerEntity>();
        foreach (var r in results)
        {
            names.Add(r);
        }
        return names;
    }
}