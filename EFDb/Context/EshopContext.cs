using EFDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDb.Context;

public class EshopContext : DbContext
{
    public EshopContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Encrypt=False;Trusted_Connection=Yes");
    }

    public DbSet<Commodity> Comodities { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Review> Reviews { get; set; }
}