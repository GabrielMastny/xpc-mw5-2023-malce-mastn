using System.Collections.Generic;

namespace Eshop.API.Dtos;

public class DemoDTO
{
    public IEnumerable<CategoryDTO> Categories { get; set; }

    public IEnumerable<ManufacturerBriefDTO> Manufacturers { get; set; }

    public IEnumerable<CommodityDto> Commodities { get; set; }
}