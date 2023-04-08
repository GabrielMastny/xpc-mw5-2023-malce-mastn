using App.DAL.Entities;
using Bogus;

namespace App.DAL;

public class GenerateDatabase : IDisposable
{

    public ICollection<CommodityEntity> init(int number)
    {
        var faker = new Faker<CommodityEntity>()
            .UseSeed(100)
            .RuleFor(c => c.Name, f => f.Name.FirstName())
            .RuleFor(c => c.Image, f => f.Random.String(1))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.Price, f => f.Random.Number(1, 1000))
            .RuleFor(c => c.Weight, f => f.Random.Number(1, 100))
            .RuleFor(c => c.NumberOfPiecesInStock, f => f.Random.Int(0, 2000))
            .RuleFor(c => c.Manufacturer, f => GenerateFakeManufacturer())
            .RuleFor(c => c.Category, f => GenerateFakeCategory());

        return faker.Generate(number);
    }

    public ICollection<ReviewEntity> GenerateFakeReviews(int number)
    {
        return new Faker<ReviewEntity>()
            //.UseSeed(99)
            .RuleFor(r => r.Stars, f => f.Random.Int(0, 5))
            .RuleFor(r => r.Description, f => f.Lorem.Sentence())
            .RuleFor(r => r.Title, f => f.Name.FirstName())
            .Generate(number);
    }

    private Faker<CategoryEntity> GenerateFakeCategory()
    {
        return new Faker<CategoryEntity>()
            .UseSeed(98)
            .RuleFor(c => c.Name, f => f.Name.FirstName());
    }

    private Faker<ManufacturerEntity> GenerateFakeManufacturer()
    {
        return new Faker<ManufacturerEntity>()
            .UseSeed(97)
            .RuleFor(m => m.Name, f => f.Name.FirstName())
            .RuleFor(m => m.Description, f => f.Lorem.Sentence())
            .RuleFor(m => m.Image, f => f.Random.String(1))
            .RuleFor(m => m.CountryOfOrigin, f => f.Name.FirstName());
    }

    public void Dispose()
    {
        Console.WriteLine("Disposing database generator");
    }
}