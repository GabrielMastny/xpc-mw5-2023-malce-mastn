namespace Eshop.API.Interfaces;

public interface IReview : IWithId
{
    int Stars { get; set; }
    string Title { get; set; }
    string Description { get; set; }
}