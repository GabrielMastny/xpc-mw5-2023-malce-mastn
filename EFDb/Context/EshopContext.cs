using EFDb.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDb.Context;

public class EshopContext : DbContext
{
    public EshopContext()
    {
        
    }
    
    public DbSet<Commodity> Comodities { get; set; }
}