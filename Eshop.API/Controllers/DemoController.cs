using System;
using System.Collections.Generic;
using System.Linq;
using Eshop.DAL;
using Eshop.DAL.Entities;
using AutoMapper;
using Eshop.API.Dtos;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.QueryObjects.Filters;
using Eshop.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eshop.API.Controllers;

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

    private readonly GetCategoriesByCategoryFilterQuery _catQuery;
    private readonly GetManufacturersByManufacturerDataFilterQuery _manQuery;
    private readonly GetCommoditiesByCommodityDataFilterQuery _comQuery;
    private readonly GetReviewsByReviewFilterQuery _revQuery;
    
    public DemoController(ILogger<CategoryController> logger, 
        IMapper mapper, 
        IRepository<CategoryEntity> catRepo,
        IRepository<ManufacturerEntity> manRepo,
        IRepository<CommodityEntity> comRepo,
        IRepository<ReviewEntity> revRepo,
        GetCategoriesByCategoryFilterQuery catQuery,
        GetManufacturersByManufacturerDataFilterQuery manQuery,
        GetCommoditiesByCommodityDataFilterQuery comQuery,
        GetReviewsByReviewFilterQuery revQuery)
    {
        _logger = logger;
        _catRepo = catRepo;
        _manRepo = manRepo;
        _comRepo = comRepo;
        _revRepo = revRepo;
        _mapper = mapper;
        
        _catQuery = catQuery;
        _manQuery = manQuery;
        _comQuery = comQuery;
        _revQuery = revQuery;
    }

    [HttpGet(Name = "GetWholeDb")]
    public DemoDTO Get()
    {
        var coms = new List<CommodityDto>();
        foreach (var comEnt in _comQuery.Execute(new CommodityDataFilter()))
        {
            coms.Add(_mapper.Map<CommodityDto>(comEnt));
        }
        
        var cats = new List<CategoryDTO>();
        foreach (var catEnt in _catQuery.Execute(new CategoryFilter()))
        {
            cats.Add(_mapper.Map<CategoryDTO>(catEnt));
        }
        
        var mans = new List<ManufacturerBriefDTO>();
        foreach (var manEnt in _manQuery.Execute(new ManufacturerDataFilter()))
        {
            mans.Add(_mapper.Map<ManufacturerBriefDTO>(manEnt));
        }
        
        return new DemoDTO()
        {
            Categories = cats,
            Manufacturers = mans,
            Commodities = coms
        };
    }
    
    [HttpPost]
    [Route($"[action]")]
    public ActionResult BuildDatabaseData()
    {
        GenerateDatabase dbBuilder = new GenerateDatabase();

        ManufacturerEntity manufacturer = null;
        CategoryEntity category = null;

        for (int i = 0; i < 16; i++)
        {
            if (i % 4 == 0)
            {
                manufacturer = dbBuilder.GenerateManufacturerEntity();
                category = dbBuilder.GenerateCaterogyEntity();
        
                _manRepo.Create(manufacturer);
                _catRepo.Create(category);   
            }
        
            CommodityEntity commodity = dbBuilder.GenerateCommodityEntity();

            commodity.Manufacturer = manufacturer;
            commodity.Category = category;
        
            foreach (var review in dbBuilder.GenerateFakeReviewsTest(3))
            {
                review.RelatedTo = commodity;
                _revRepo.Create(review);
            }
        
            _comRepo.Create(commodity);
        }
        
        dbBuilder.Dispose();

        return new OkResult();
    }
    
    [HttpDelete]
    [Route($"[action]")]
    public void ClearDatabase()
    {
        foreach (var revId in _revQuery.Execute(new ReviewFilter()).ToList())
        {
            _revRepo.Delete(revId.Id);
        }
        
        foreach (var commodity in _comQuery.Execute(new CommodityDataFilter()).ToList())
        {
            _comRepo.Delete(commodity.Id);
        }
        
        foreach (var manufacturer in _manQuery.Execute(new ManufacturerDataFilter()).ToList())
        {
            _manRepo.Delete(manufacturer.Id);
        }
        
        foreach (var category in _catQuery.Execute(new CategoryFilter()).ToList())
        {
            _catRepo.Delete(category.Id);
        }
    }
    
#endif
}