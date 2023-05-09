using System;

namespace Eshop.API.Dtos;

public class ReviewCreateDTO
{
    
    public Guid RelatedTo { get; set; }
    public int Stars { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}