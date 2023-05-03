namespace CommonDbProperties.Interfaces.Entities;

public interface ICommodity : IItemable
{
    double Price { get; set; }
    double Weight { get; set; }
    int NumberOfPiecesInStock { get; set; }
}