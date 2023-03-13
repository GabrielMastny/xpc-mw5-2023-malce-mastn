using System;
using System.Collections.Generic;
using App.DAL.Entities;

namespace App.DAL;

public class Database
{
    private static readonly Lazy<Database> LazyDatabase =
        new Lazy<Database>(() => new Database());
    
    public static Database Instance => LazyDatabase.Value;

    private Database()
    {
    }
    
    public ICollection<CommodityEntity> Commodities { get; } = new List<CommodityEntity>();
    public ICollection<ManufacturerEntity> Manufacturers { get; } = new List<ManufacturerEntity>();
    public ICollection<CategoryEntity> Categories { get; } = new List<CategoryEntity>();
    //public ICollection<ReviewEntity> Reviews{ get; } = new List<ReviewEntity>();

    public void ShowData()
    {
        Console.WriteLine("--------------------------");
        
        Console.WriteLine("# Commodities:");
        foreach (var c in Commodities)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("# Courses:");
        foreach (var m in Manufacturers)
        {
            Console.WriteLine(m);
        }
        
        Console.WriteLine("# Exams:");
        foreach (var c in Categories)
        {
            Console.WriteLine(c);
        }

        Console.WriteLine("--------------------------");
    }
}