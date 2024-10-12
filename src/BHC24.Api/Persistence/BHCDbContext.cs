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
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BHC24.db");
    }
}