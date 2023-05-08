using Eshop.DAL.Entities;

namespace Eshop.DAL.Mappers;

public interface IMapper<Tentity, Tmodel> where Tentity : EntityBase where Tmodel : IModel
{
    Tmodel Map(Tentity entity);
    Tentity ReverseMap(Tmodel model);
}