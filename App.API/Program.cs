using System.Security.Authentication.ExtendedProtection;
using App.DAL;
using App.DAL.Entities;
using App.DAL.QueryObjects;
using App.DAL.QueryObjects.Filters;
using App.DAL.Repositories;
using CommonDbProperties.Interfaces.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace App.API;

class Program
{
    
    public static void Main(string[] args)
    {
        
        CommodityRepository commodityRepository = new CommodityRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        ManufacturerRepository manufacturerRepository = new ManufacturerRepository();
        ReviewRepository reviewRepository = new ReviewRepository();

        var services = new ServiceCollection();
        services.AddScoped<GenerateDatabase>();
        var serviceProvider = services.BuildServiceProvider();
        var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        
        
        
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var generateCommodities = scope.ServiceProvider.GetRequiredService<GenerateDatabase>();    

            var commodities = generateCommodities.init(100);
            
            foreach (var c in commodities)
            {
                c.Manufacturer = manufacturerRepository.ReturnOrCreate(c.Manufacturer);
                c.Category = categoryRepository.ReturnOrCreate(c.Category);
                commodityRepository.Create(c);

                foreach (var r in generateCommodities.GenerateFakeReviews(3))
                {
                    c.Reviews.Add(reviewRepository.GetById(reviewRepository.Create(r)));
                }
            }

        }    
        
        //Database.Instance.ShowData();
        
        Console.WriteLine("\nManufacturer Greta");
        var man = manufacturerRepository.GetByName("Greta");
        foreach (var c in man.ListOfCommodities)
        {
            Console.WriteLine(c.Name);
        }
        
        Console.WriteLine("\n###### Filter test ######");
        Console.WriteLine("\n### Category filter: Thomas");
        var categories = new GetCategoryByCategoryFilterQuery().Execute(new CategoryFilter() { Name = "Thomas" });
        foreach (var c in categories)
        {
            Console.WriteLine(c.Name);
        }
        
        Console.WriteLine("\n### Manufacturer filter: ");
        var manufacturers = new GetManufacturersByManufacturerDataFilterQuery().Execute(new ManufacturerDataFilter()
        {
            CountryOfOrigin = "Wiley"
        });

        foreach (var m in manufacturers)
        {
            Console.WriteLine(m.Name);
        }
        
        Console.WriteLine("\n### Commodity filter: ");
        var comms = new GetCommoditiesByDataFilterQuery().Execute(new CommodityDataFilter()
        {
            Price = new double?[]{1,200},
            NumberOfPiecesInStock = 200,
            Weight = new double?[]{10, 20}
        });

        foreach (var c in comms)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("\n### Review filter: ");
        var reviews = new GetReviewsByReviewFilterQuery().Execute(new ReviewFilter() { Stars = 2 });

        foreach (var r in reviews)
        {
            Console.WriteLine(r);
        }
        
        //Console.WriteLine("\n### Complex filter: ");
        
    }

}

