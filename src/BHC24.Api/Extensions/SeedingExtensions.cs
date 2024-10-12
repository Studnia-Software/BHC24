﻿using BHC24.Api.Persistence;

namespace BHC24.Api.Persistence.Models;

public class SeedingExtensions
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder builder)
    {
        var scope = builder.ApplicationServices.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var dbContext = serviceProvider.GetService<BhcDbContext>();
      
        ArgumentNullException.ThrowIfNull(dbContext);
        
        //UserSeeder.Seed(dbContext);
        //ProjectSeeder.Seed(dbContext);
        return builder;
    }
}