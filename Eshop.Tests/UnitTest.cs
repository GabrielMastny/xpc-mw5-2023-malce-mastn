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
    private CommodityController _comController;
    private ManufacturerController _manController;
    private CategoryController _catController;
    private ReviewController _reviewController;

    private CategoryDTO _cDto;
    private ManufacturerDTO _mDto;
    private CommodityDto _comDto;
    private ReviewDTO _reviewDto;
    
    private string _idOfAddedComm;
    private ApiVersion _apiV;
    
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
        
        CommodityRepository rep = new CommodityRepository(db);
        var logger = logFactory.CreateLogger<CommodityController>();
        _comController = new CommodityController(logger, rep, mapp, new GetCommoditiesByCommodityDataFilterQuery(db));
        
        ManufacturerRepository manRep = new ManufacturerRepository(db, mapp);
        var manLogger = logFactory.CreateLogger<ManufacturerController>();
        _manController = new ManufacturerController(manLogger, manRep, mapp,
            new GetManufacturersByManufacturerDataFilterQuery(db));

        CategoryRepository catRep = new CategoryRepository(db, mapp);
        var catLogger = logFactory.CreateLogger<CategoryController>();
        _catController = new CategoryController(catLogger, catRep, mapp, new GetCategoriesByCategoryFilterQuery(db));

        ReviewRepository revRep = new ReviewRepository(db, mapp);
        var revLogger = logFactory.CreateLogger<ReviewController>();
        _reviewController = new ReviewController(revLogger, revRep, mapp, new GetReviewsByReviewFilterQuery(db));

        _apiV = new ApiVersion(DateTime.Today);
        
        _cDto = new CategoryDTO()
        {
            Description = "Description of category",
            Image = "Image of category",
            Name = "Name of category",
            Id = Guid.Empty,
        };

        _mDto = new ManufacturerDTO()
        {
            Description = "Description of manufacture",
            Id = Guid.Empty,
            Image = "Image of manufacturer",
            Name = "Name of manufacturer",
            CountryOfOrigin = "CZ",
        };

        _comDto = new CommodityDto()
        {
            Description = "Commodity test describtion",
            Image = "Image of commodity",
            Name = "Commodity name",
            Price = 122,
            Weight = 34,
            NumberOfPiecesInStock = 1234,
        };

        _reviewDto = new ReviewDTO()
        {
            Description = "Review describtion in test",
            Id = Guid.Empty,
            RelatedTo = _comDto,
            Stars = 3,
            Title = "Review test title"
        };

    }

    [Test]
    public void AddCategory()
    {
        var res = _catController.AddCategory(_apiV,
            new CategoryCreateDTO()
            {
                Name = _cDto.Name, 
                Description = _cDto.Description, 
                Image = _cDto.Image
            });
        Assert.IsInstanceOf<OkObjectResult>(res.Result);

        _cDto.Id = (Guid)((res.Result as OkObjectResult).Value);
    }
    
    [Test]
    public void AddManufacturer()
    {
        var res = _manController.AddManufacturer(_apiV,
            new ManufacturerCreateDTO()
            {
                Name = _mDto.Name, 
                Description = _mDto.Description, 
                Image = _mDto.Image, 
                CountryOfOrigin = _mDto.CountryOfOrigin
            });
        Assert.IsInstanceOf<OkObjectResult>(res.Result);

        _mDto.Id = (Guid)((res.Result as OkObjectResult).Value);
    }
    
    [Test]
    public void AddCommodity()
    {
        var result = _comController.AddCommodity(_apiV, new CommodityCreateDto()
        {
            Name = _comDto.Name,
            Description = _comDto.Description,
            Category = _cDto,
            Manufacturer = _mDto,
            Image = _comDto.Image,
            NumberOfPiecesInStock = _comDto.NumberOfPiecesInStock,
            Price = _comDto.Price,
            Weight = _comDto.Weight
        });
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    public void AddReview()
    {
        var result = _reviewController.AddReview(_apiV, new ReviewCreateDTO()
        {
            Description = _reviewDto.Description,
            RelatedTo = _comDto,
            Stars = _reviewDto.Stars,
            Title = _reviewDto.Title
        });
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    [Test]
    public void GetCommodityTest()
    {
        var x = _comController.Get(_apiV);
        Assert.IsInstanceOf<OkObjectResult>(x);
    }
    
    [Test]
    public void GetCategoryTest()
    {
        var x = _catController.Get(_apiV);
        Assert.IsInstanceOf<OkObjectResult>(x.Result);
    }
    
    [Test]
    public void GetManufacturerTest()
    {
        var x = _manController.Get(_apiV);
        Assert.IsInstanceOf<OkObjectResult>(x.Result);
    }
    
    [Test]
    public void GetReviewTest()
    {
        var x = _reviewController.Get(_apiV);
        Assert.IsInstanceOf<OkObjectResult>(x.Result);
    }

    [Test]
    public void GetCommodityById()
    {
        //var x = _comController.GetSingleCommodity(_comDto);
    }
}