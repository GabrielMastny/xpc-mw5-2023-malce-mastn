using System;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class CommodityBriefDto : IItemable
{
    public required string Name { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public required double Price { get; set; }
    public double Weight { get; set; }
    public int NumberOfPiecesInStock { get; set; }
    public int ReviewCount { get; set; }
    public Guid Id { get; set; }
}