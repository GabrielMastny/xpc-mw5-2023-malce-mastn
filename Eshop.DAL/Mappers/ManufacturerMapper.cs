using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public class ManufacturerMapper : IMapper<ManufacturerEntity, Manufacturer>
{
    public Manufacturer Map(ManufacturerEntity entity)
    {
        return new Manufacturer()
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            CountryOfOrigin = entity.CountryOfOrigin,
            Description = entity.Description,
            Image = entity.Image
        };
    }

    public ManufacturerEntity ReverseMap(Manufacturer model)
    {
        return new ManufacturerEntity()
        {
            Id = Guid.Parse(model.Id),
            Name = model.Name,
            CountryOfOrigin = model.CountryOfOrigin,
            Description = model.Description,
            Image = model.Image
        };
    }
}