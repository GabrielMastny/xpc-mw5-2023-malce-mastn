using AutoMapper;
using Eshop.API.Controllers;
using Eshop.API.MappingProfiles;
using Eshop.DAL.Context;
using Eshop.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace Eshop.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        EshopContext db = new EshopContext();
        MapperConfigurationExpression cc = new MapperConfigurationExpression();
        IConfigurationProvider c = new MapperConfiguration(cc);
        IMapper mapp = new Mapper(c);
        CommodityRepository rep = new CommodityRepository(db, mapp);
        
        //CommodityController controller = new CommodityController()
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}