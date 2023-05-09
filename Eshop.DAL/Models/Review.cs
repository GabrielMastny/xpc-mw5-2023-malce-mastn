using System;
using System.Collections.Generic;

namespace Eshop.DAL;

public partial class Review : IModel
{
    public string Id { get; set; } = null!;

    public string? Description { get; set; }

    public string? Title { get; set; }

    public int Stars { get; set; }

    public string CommodityId { get; set; } = null!;

    public virtual Commodity Commodity { get; set; } = null!;
}
