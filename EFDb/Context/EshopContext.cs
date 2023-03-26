using EFDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDb.Context;

public class EshopContext : DbContext
{
    public EshopContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Commodity> Comodities { get; set; } = null;
    public DbSet<Category> Categories { get; set; } = null;
    public DbSet<Manufacturer> Manufacturers { get; set; } = null;
    public DbSet<Review> Reviews { get; set; } = null;
}