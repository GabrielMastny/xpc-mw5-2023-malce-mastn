using System;
using System.Collections.Generic;

namespace Eshop.DAL;

public partial class Category : IModel
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Commodity> Commodities { get; } = new List<Commodity>();
}
