using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Startup;

public class TagSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Tags.Any())
        {
            return;
        }

        var tags = new Tag[]
        {
            new()
            {
                Name = "html"
            },

            new()
            {
                Name = "css"
            },
            
            new()
            {
                Name = "javascript"
            },
            
            new()
            {
                Name = "c#"
            },
            
            new()
            {
                Name = "python"
            },
            new()
            {
                Name = "php"
            }
        };

        dbContext.Tags.AddRange(tags);
        dbContext.SaveChanges();
    }
}