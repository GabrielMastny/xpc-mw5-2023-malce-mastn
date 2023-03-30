using System.ComponentModel.DataAnnotations.Schema;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;

namespace EFDb.Models;

[Table("Review")]
public class Review : TableBase, IReview
{
    public string Description { get; set; }
    public string Title { get; set; }
    public required int Stars { get; set; }
}