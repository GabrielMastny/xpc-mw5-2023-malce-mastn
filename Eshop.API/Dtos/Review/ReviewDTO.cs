using System;
using Eshop.API.Interfaces;

namespace Eshop.API.Dtos;

public class ReviewDTO : ReviewCreateDTO, IReview
{
    public Guid Id { get; set; }
}