using System;
using System.Collections.Generic;
using System.Linq;
using Eshop.DAL;
using Eshop.DAL.Entities;
using AutoMapper;
using CommonDbProperties.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Dtos;

namespace WebAPI.Controllers;

#if DEBUG
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class DemoController
{
    private readonly ILogger<CategoryController> _logger;
    private readonly IRepository<CategoryEntity> _catRepo;
    private readonly IRepository<ManufacturerEntity> _manRepo;
    private readonly IRepository<CommodityEntity> _comRepo;
    private readonly IRepository<ReviewEntity> _revRepo;
    private readonly IMapper _mapper;
    
    public DemoController(ILogger<CategoryController> logger, IMapper mapper, IRepository<CategoryEntity> catRepo,
                                                                              IRepository<ManufacturerEntity> manRepo,
                                                                              IRepository<CommodityEntity> comRepo,
                                                                              IRepository<ReviewEntity> revRepo)
    {
        _logger = logger;
        _catRepo = catRepo;
        _manRepo = manRepo;
        _comRepo = comRepo;
        _revRepo = revRepo;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetWholeDb")]
    public DemoDTO Get()
    {
        var coms = new List<CommodityDto>();
        foreach (var comEnt in _comRepo.Get())
        {
            coms.Add(_mapper.Map<CommodityDto>(comEnt));
        }

        return new DemoDTO()
        {
            Categories = _catRepo.Get().Select(x => _mapper.Map<CategoryDTO>(x)),
            Manufacturers = _manRepo.Get().Select(x => _mapper.Map<ManufacturerBriefDTO>(x)),
            Commodities = coms
        };
    }

    [HttpPost]
    [Route($"[action]")]
    public ActionResult BuildDefaultDatabaseData()
    {
        GenerateDatabase dbBuilder = new GenerateDatabase();
        Dictionary<Guid, Guid> manufacturers = new Dictionary<Guid, Guid>();
        Dictionary<Guid, Guid> categories = new Dictionary<Guid, Guid>();

        foreach (var commodity in dbBuilder.init(30))
        {
            Guid manId = Guid.Empty;
            
            if (!manufacturers.ContainsKey(commodity.Manufacturer.Id))
            {
                manId = _manRepo.Create(commodity.Manufacturer);
                manufacturers[commodity.Manufacturer.Id] = manId;
            }
            else
            {
                manId = manufacturers[commodity.Manufacturer.Id];
            }
            
            Guid catId = Guid.Empty;
            
            if (!categories.ContainsKey(commodity.Category.Id))
            {
                catId = _catRepo.Create(commodity.Category);
                categories[commodity.Category.Id] = catId;
            }
            else
            {
                catId = categories[commodity.Category.Id];
            }

            commodity.Category.Id = catId;
            commodity.Manufacturer.Id = manId;
            
            var comId = _comRepo.Create(commodity);
            commodity.Id = comId;
            foreach (var review in dbBuilder.GenerateFakeReviews(30))
            {
                review.RelatedTo = commodity;
                _revRepo.Create(review);
            }
        }
        
        dbBuilder.Dispose();

        return new OkResult();
    }
    
    [HttpPost]
    [Route($"[action]")]
    public void ClearDatabase()
    {
        List<Guid> revIds = new List<Guid>();
        
        foreach (var commodity in _comRepo.Get().ToList())
        {
            _comRepo.Delete(commodity.Id);

            foreach (var review in commodity.Reviews)
            {
                revIds.Add(review.Id);
            }
        }

        foreach (var revId in revIds)
        {
            _revRepo.Delete(revId);
        }

        foreach (var manufacturer in _manRepo.Get().ToList())
        {
            _manRepo.Delete(manufacturer.Id);
        }

        foreach (var category in _catRepo.Get().ToList())
        {
            _catRepo.Delete(category.Id);
        }
    }
    
    
    #endif
}