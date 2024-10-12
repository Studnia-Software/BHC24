using Api.Persistence;
using Api.Persistence.Models;

namespace Api.Startup;

public class TagSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Tag.Any())
        {
            return;
        }

        var tags = new Tag[]
        {
            new()
            {
                Name = "html"
            }

            new()
            {
                Name = "css"
            }
            
            new()
            {
                Name = "javascript"
            }
            
            new()
            {
                Name = "c#"
            }
            
            new()
            {
                Name = "python"
            }
        };

        dbContext.Tag.AddRange(tags);
        dbContext.SaveChanges();
    }
}