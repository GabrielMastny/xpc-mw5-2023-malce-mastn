using System.Security.Authentication.ExtendedProtection;
using App.DAL;
using App.DAL.Entities;
using App.DAL.QueryObjects;
using App.DAL.QueryObjects.Filters;
using App.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace App.API;

class Program
{

    public static readonly CommodityRepository _commodityRepository = new CommodityRepository();
    public static readonly CategoryRepository _categoryRepository = new CategoryRepository();
    public static readonly ManufacturerRepository _manufacturerRepository = new ManufacturerRepository();
    public static readonly ReviewRepository _reviewrepository = new ReviewRepository();

    public static void Main(string[] args)
    {

        var services = new ServiceCollection();

        services.AddScoped<GenerateDatabase>();
        
        var serviceProvider = services.BuildServiceProvider();

        var serviceScopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
        
        using (var scope = serviceScopeFactory.CreateScope())
        {
            var generateCommodieties = scope.ServiceProvider.GetRequiredService<GenerateDatabase>();

            var commodities = generateCommodieties.init(10);
            
            foreach (var c in commodities)
            {
                c.Manufacturer = _manufacturerRepository.ReturnOrCreate(c.Manufacturer);
                c.Category = _categoryRepository.ReturnOrCreate(c.Category);
                _commodityRepository.Create(c);

                foreach (var r in generateCommodieties.GenerateFakeReviews(3))
                {
                    c.Reviews.Add(_reviewrepository.GetById(_reviewrepository.Create(r)));
                }
            }

        }    
        
        Database.Instance.ShowData();
        
        Console.WriteLine("\nManufacturer Greta");
        var man = _manufacturerRepository.GetByName("Greta");
        foreach (var c in man.ListOfCommodities)
        {
            Console.WriteLine(c.Name);
        }
        //
        // Console.WriteLine("\nReviews for commodity Vivienne");
        // var commodity = _commodityRepository.GetByName("Vivienne");
        // foreach (var r in commodity.Reviews)
        // {
        //     Console.WriteLine(r);
        // }
        //
        // var p = _commodityRepository.GetByName("Vivienne");
        // _commodityRepository.Delete(p.Id);
        //
        // Console.WriteLine("###################################################################################");
        
        //Database.Instance.ShowData();
    }

}

