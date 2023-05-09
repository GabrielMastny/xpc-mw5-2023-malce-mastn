using System;
using System.Collections.Generic;

namespace Eshop.DAL;

public partial class Commodity : IModel
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Image { get; set; }

    public string? Describtion { get; set; }

    public double Price { get; set; }

    public double Weight { get; set; }

    public int NumberOfPiecesInStock { get; set; }

    public string CategoryId { get; set; } = null!;

    public string ManufacturerId { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
