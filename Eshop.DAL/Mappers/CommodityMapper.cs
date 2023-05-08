using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public class CommodityMapper : IMapper<CommodityEntity, Commodity>
{
    public Commodity Map(CommodityEntity entity)
    {
        return new Commodity()
        {
            Id = entity.Id.ToString(),
            Name = entity.Name,
            CategoryId = entity.Category.Id.ToString(),
            ManufacturerId = entity.Manufacturer.Id.ToString(),
            Describtion = entity.Description,
            Price = entity.Price,
            Weight = entity.Weight,
            Image = entity.Image,
            NumberOfPiecesInStock = entity.NumberOfPiecesInStock
        };
    }

    public CommodityEntity ReverseMap(Commodity model)
    {
        // return new CommodityEntity()
        // {
        //     Id = entity.Id.ToString(),
        //     Name = model.Name,
        //     CategoryId = entity.Category.Id.ToString(),
        //     ManufacturerId = entity.Manufacturer.Id.ToString(),
        //     Describtion = entity.Description,
        //     Price = entity.Price,
        //     Weight = entity.Weight,
        //     Image = entity.Image,
        //     NumberOfPiecesInStock = entity.NumberOfPiecesInStock
        // };
        return null;
    }
}