using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public class CommodityMapper : IMapper<CommodityEntity, Commodity>
{

    private readonly CategoryMapper _categoryMapper = new CategoryMapper();
    private readonly ManufacturerMapper _manufacturerMapper = new ManufacturerMapper();
    private readonly ReviewMapper _reviewMapper = new ReviewMapper();
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
        var commodity =  new CommodityEntity()
        {
            Id = Guid.Parse(model.Id),
            Name = model.Name,
            Description = model.Describtion,
            Category = _categoryMapper.ReverseMap(model.Category),
            Manufacturer = _manufacturerMapper.ReverseMap(model.Manufacturer),
            Price = model.Price,
            Weight = model.Weight,
            Image = model.Image,
            NumberOfPiecesInStock = model.NumberOfPiecesInStock
        };

        foreach (var r in model.Reviews)
        {
            commodity.Reviews.Add(_reviewMapper.ReverseMap(r));
            Console.WriteLine("mapper review");
        }

        return commodity;
    }
}