using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Persitence;

public class BHCDbContext : DbContext
{
    public BHCDbContext()
    {
        
    }
    
    public BHCDbContext(DbContextOptions<BHCDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BHC24.db");
    }
}