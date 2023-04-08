using System;
using CommonDbProperties.Interfaces.Entities;

namespace WebAPI.Dtos;

public class ReviewDTO : ReviewCreateDTO, IReview
{
    public Guid Id { get; set; }
}