using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BHC24.Api.Persistence;

public class BhcDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public BhcDbContext()
    {
        
    }
    
    public BhcDbContext(DbContextOptions<BhcDbContext> options) : base(options)
    {
        
    }

    public DbSet<Investor> Investors => Set<Investor>();
    public DbSet<Offer> Offers => Set<Offer>();
    
    public override int SaveChanges()
    {
        AdjustTrackableEntities();
        return base.SaveChanges();
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AdjustTrackableEntities();
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    private void AdjustTrackableEntities()
    {
        var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseTrackingEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((BaseTrackingEntity) entry.Entity).CreatedAt = DateTime.Now;
            }
            else
            {
                ((BaseTrackingEntity) entry.Entity).UpdatedAt = DateTime.Now;
            }
        }
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BHC24.db");
    }
}