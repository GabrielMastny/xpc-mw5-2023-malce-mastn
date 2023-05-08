using Eshop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshop.DAL.Context;

public class EshopContext : DbContext
{
    public EshopContext(DbContextOptions options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Encrypt=False;Trusted_Connection=Yes");
    }

    public DbSet<CommodityEntity> Comodities { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
}