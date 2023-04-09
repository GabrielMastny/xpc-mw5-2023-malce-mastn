using App.DAL.Entities;
using App.DAL.QueryObjects.Filters;
using CommonDbProperties.Interfaces.QueryObjects;

namespace EFDb.QueryObjects;

public class GetManufacturersByManufacturerDataFilterQuery : IQuery<ManufacturerEntity, ManufacturerDataFilter>
{
    public IEnumerable<ManufacturerEntity> Execute(ManufacturerDataFilter filter)
    {
        throw new NotImplementedException();
    }
}