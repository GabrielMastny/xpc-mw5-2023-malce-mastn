using Eshop.API.Interfaces;

namespace CommonDbProperties.Interfaces.Entities;

public interface IItemable : IWithId
{
    string Name { get; set; }
    string Description { get; set; }
    string Image { get; set; }
}