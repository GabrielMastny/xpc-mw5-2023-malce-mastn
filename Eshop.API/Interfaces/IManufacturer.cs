namespace CommonDbProperties.Interfaces.Entities;

public interface IManufacturer : IItemable
{
    string CountryOfOrigin { get; set; }
}