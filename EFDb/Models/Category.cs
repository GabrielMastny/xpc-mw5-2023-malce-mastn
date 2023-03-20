using System.ComponentModel.DataAnnotations.Schema;

namespace EFDb.Models;

[Table("Category")]
public class Category
{
    public string Name { get; set; }
}