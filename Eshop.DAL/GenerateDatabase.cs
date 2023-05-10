using Bogus;
using Eshop.DAL.Entities;

namespace Eshop.DAL;

public class GenerateDatabase : IDisposable
{
    private List<ManufacturerEntity> manufacturers = new List<ManufacturerEntity>();
    private List<CategoryEntity> categories = new List<CategoryEntity>();
    private Random rnd = new Random();
    private const int RATIO = 4;
    public ICollection<CommodityEntity> init(int number)
    {
        var faker = new Faker<CommodityEntity>()
            .UseSeed(100)
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Image, f => f.Random.String(1))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.Price, f => f.Random.Number(1, 1000))
            .RuleFor(c => c.Weight, f => f.Random.Number(1, 100))
            .RuleFor(c => c.NumberOfPiecesInStock, f => f.Random.Int(0, 2000));
            //.RuleFor(c => c.Manufacturer, f => GenerateFakeManufacturer(number))
            //.RuleFor(c => c.Category, f => GenerateFakeCategory(number));

        return faker.Generate(number);
    }

    public CommodityEntity GenerateCommodityEntity()
    {
        return new Faker<CommodityEntity>()
            //.UseSeed(100)
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Image, f => f.Random.String(1))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.Price, f => f.Random.Number(1, 1000))
            .RuleFor(c => c.Weight, f => f.Random.Number(1, 100))
            .RuleFor(c => c.NumberOfPiecesInStock, f => f.Random.Int(0, 2000))
            .Generate();
    }

    public ManufacturerEntity GenerateManufacturerEntity()
    {
        return new Faker<ManufacturerEntity>()
            //.UseSeed(97)
            .RuleFor(m => m.Id, f => Guid.NewGuid())
            .RuleFor(m => m.Name, f => f.Name.FirstName())
            .RuleFor(m => m.Description, f => f.Lorem.Sentence())
            .RuleFor(m => m.Image, f => f.Random.String(1))
            .RuleFor(m => m.CountryOfOrigin, f => f.Name.FirstName())
            .Generate();
    }

    public CategoryEntity GenerateCaterogyEntity()
    {
        return new Faker<CategoryEntity>()
            //.UseSeed(98)
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.Image, f => f.Image.Random.String())
            .Generate();
    }

    public ICollection<ReviewEntity> GenerateFakeReviewsTest(int count)
    {
        return new Faker<ReviewEntity>()
            //.UseSeed(99)
            .RuleFor(r => r.Id, f => Guid.NewGuid())
            .RuleFor(r => r.Stars, f => f.Random.Int(0, 5))
            .RuleFor(r => r.Description, f => f.Lorem.Sentence())
            .RuleFor(r => r.Title, f => f.Name.FirstName())
            .Generate(count);
    }
    
    public ICollection<ReviewEntity> GenerateFakeReviews(int number)
    {
        return new Faker<ReviewEntity>()
            //.UseSeed(99)
            .RuleFor(r => r.Stars, f => f.Random.Int(0, 5))
            .RuleFor(r => r.Description, f => f.Lorem.Sentence())
            .RuleFor(r => r.Title, f => f.Name.FirstName())
            .Generate( rnd.Next(number/ RATIO));
    }

    private CategoryEntity GenerateFakeCategory(int count)
    {
        if (categories.Count < count / RATIO)
        {
            var cat =  new Faker<CategoryEntity>()
                .UseSeed(98)
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.FirstName())
                .RuleFor(c => c.Description, f => f.Lorem.Sentence())
                .RuleFor(c => c.Image, f => f.Image.Random.String())
                .Generate();
            
            categories.Add(cat);
            return cat;
        }
        else
        {
            return categories.ElementAt(rnd.Next(categories.Count));
        }
        
        

    }

    private ManufacturerEntity GenerateFakeManufacturer(int count)
    {
        if (manufacturers.Count() < count / RATIO)
        {
           var man = new Faker<ManufacturerEntity>()
                .UseSeed(97)
                .RuleFor(m => m.Id, f => Guid.NewGuid())
                .RuleFor(m => m.Name, f => f.Name.FirstName())
                .RuleFor(m => m.Description, f => f.Lorem.Sentence())
                .RuleFor(m => m.Image, f => f.Random.String(1))
                .RuleFor(m => m.CountryOfOrigin, f => f.Name.FirstName())
                .Generate();
           manufacturers.Add(man);
           return man;
        }
        else
        {
            return manufacturers.ElementAt(rnd.Next(manufacturers.Count));
        }
        
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing database generator");
    }
}