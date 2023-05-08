﻿using System.ComponentModel.DataAnnotations.Schema;
using Eshop.DAL.Entities;

namespace Eshop.DAL.Entities;

[Table("Commodity")]
public class CommodityEntity : TableBase, IEntity
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public required CategoryEntity Category { get; set; }
    public required ManufacturerEntity Manufacturer { get; set; }
}