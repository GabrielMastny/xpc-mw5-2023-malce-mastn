﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommonDbProperties.Interfaces;
using CommonDbProperties.Interfaces.Entities;

namespace EFDb.Models;

[Table("Category")]
public class Category : ICategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
}