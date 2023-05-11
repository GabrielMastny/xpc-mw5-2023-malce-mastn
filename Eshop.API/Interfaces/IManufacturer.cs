namespace Eshop.API.Interfaces;

public interface IManufacturer : IItemable
{
    string CountryOfOrigin { get; set; }
}