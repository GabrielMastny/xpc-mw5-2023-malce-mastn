using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eshop.DAL.Entities;

[Table("Category")]
public class CategoryEntity : TableBase, IEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}