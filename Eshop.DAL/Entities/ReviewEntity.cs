using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.DAL.Entities;

[Table("Review")]
public class ReviewEntity : TableBase
{
    public string Description { get; set; }
    public string Title { get; set; }
    public required int Stars { get; set; }
    public required CommodityEntity RelatedTo { get; set; }
}