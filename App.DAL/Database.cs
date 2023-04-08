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
    public ICollection<ReviewEntity> Reviews{ get; } = new List<ReviewEntity>();

    public void ShowData()
    {
        Console.WriteLine("--------------------------");
        
        Console.WriteLine("\n# Commodities:");
        foreach (var c in Commodities)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("\n# Manufacturers:");
        foreach (var m in Manufacturers)
        {
            Console.WriteLine(m);
        }
        
        Console.WriteLine("\n# Categories:");
        foreach (var c in Categories)
        {
            Console.WriteLine(c);
        }
        
        Console.WriteLine("\n# Reviews:");
        foreach (var r in Reviews)
        {
            Console.WriteLine(r);
        }

        Console.WriteLine("--------------------------");
    }
}