using BHC24.Api.Persistence;
using BHC24.Api.Startup;

namespace BHC24.Api.Persistence.Models;

public class SeedingExtensions
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var dbContext = serviceProvider.GetService<BhcDbContext>();
      
        ArgumentNullException.ThrowIfNull(dbContext);
        
        TagSeeder.Seed(dbContext);
        UserSeeder.Seed(dbContext);
        ProjectSeeder.Seed(dbContext);
        
        return builder;
    }
}