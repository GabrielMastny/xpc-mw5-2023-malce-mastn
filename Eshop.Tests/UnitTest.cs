using AutoMapper;
using Eshop.API.Controllers;
using Eshop.API.Dtos;
using Eshop.API.MappingProfiles;
using Eshop.DAL.Context;
using Eshop.DAL.QueryObjects;
using Eshop.DAL.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Eshop.Tests;

public class Tests
{
    private CommodityController comController;
    private ManufacturerController manController;
    private CategoryController catController;

    private CategoryDTO cDto;
    private ManufacturerDTO mDto;
    private CommodityDto comDto;
    
    private string idOfAddedComm;
    private ApiVersion apiV;
    
    [SetUp]
    public void Setup()
    {
        EshopContext db = new EshopContext();
        MapperConfigurationExpression cc = new MapperConfigurationExpression();
        cc.AddProfile(new CommodityMappings());
        cc.AddProfile(new CategoryMappings());
        cc.AddProfile(new ManufacturerMappings());
        cc.AddProfile(new ReviewMappings());
        IConfigurationProvider c = new MapperConfiguration(cc);
        IMapper mapp = new Mapper(c);
        var logFactory = new LoggerFactory( new List<ILoggerProvider>());
        
        
        
        CommodityRepository rep = new CommodityRepository(db, mapp);
        var logger = logFactory.CreateLogger<Eshop.API.Controllers.CommodityController>();
        comController = new CommodityController(logger, rep, mapp, new GetCommoditiesByCommodityDataFilterQuery(db, mapp));
        
        ManufacturerRepository manRep = new ManufacturerRepository(db, mapp);
        var manLogger = logFactory.CreateLogger<Eshop.API.Controllers.ManufacturerController>();
        manController = new ManufacturerController(manLogger, manRep, mapp,
            new GetManufacturersByManufacturerDataFilterQuery(db, mapp));

        CategoryRepository catRep = new CategoryRepository(db, mapp);
        var catLogger = logFactory.CreateLogger<CategoryController>();
        catController = new CategoryController(catLogger, catRep, mapp, new GetCategoriesByCategoryFilterQuery(db, mapp));

        apiV = new ApiVersion(DateTime.Today);
        
        cDto = new CategoryDTO()
        {
            Description = "Description of category",
            Image = "Image of category",
            Name = "Name of category",
            Id = Guid.Empty,
        };

        mDto = new ManufacturerDTO()
        {
            Description = "Description of manufacture",
            Id = Guid.Empty,
            Image = "Image of manufacturer",
            Name = "Name of manufacturer",
            CountryOfOrigin = "CZ",
        };

        comDto = new CommodityDto()
        {
            Description = "",
            Image = "",
            Name = "",
            Price = 0,
            Weight = 0,
            NumberOfPiecesInStock = 0,
        };
    }

    [Test]
    public void AddCategory()
    {
        var res = catController.AddCategory(apiV,
            new CategoryCreateDTO() { Name = cDto.Name, Description = cDto.Description, Image = cDto.Image });
        Assert.IsInstanceOf<OkObjectResult>(res.Result);

        cDto.Id = (Guid)((res.Result as OkObjectResult).Value);
    }
    
    [Test]
    public void AddManufacturer()
    {
        var res = manController.AddManufacturer(apiV,
            new ManufacturerCreateDTO() { Name = mDto.Name, Description = mDto.Description, Image = mDto.Image, CountryOfOrigin = mDto.CountryOfOrigin});
        Assert.IsInstanceOf<OkObjectResult>(res.Result);

        mDto.Id = (Guid)((res.Result as OkObjectResult).Value);
    }
    
    [Test]
    public void AddCommodity()
    {
        
    }

    [Test]
    public void GetCommodityTest()
    {
        var x = comController.Get(apiV);
        Assert.IsInstanceOf<OkObjectResult>(x);
    }

    [Test]
    public void GetCommodityById()
    {
        
    }
}