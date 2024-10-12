using BHC24.Api.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Persistence;

public class BhcDbContext : DbContext
{
    public BhcDbContext()
    {
        
    }
    
    public BhcDbContext(DbContextOptions<BhcDbContext> options) : base(options)
    {
        
    }

    public DbSet<Investor> Investors => Set<Investor>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BHC24.db");
    }
}