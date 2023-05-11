namespace Eshop.API.Dtos;

public class ManufacturerCreateDTO
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public string CountryOfOrigin { get; set; }
}