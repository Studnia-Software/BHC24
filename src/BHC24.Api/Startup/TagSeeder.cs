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
                Name = "html",
                ImagePath = "src//img//html.png"
            },

            new()
            {
                Name = "css",
                ImagePath = "src//img//css.png"
            },
            
            new()
            {
                Name = "javascript",
                ImagePath = "src//img//javascript.png"
            },
            new()
            {
                Name = "c#",
                ImagePath = "src//img//csharp.png"
            },
            new()
            {
                Name = "java",
                ImagePath = "src//img//java.png"
            },
            new()
            {   
                Name ="python",
                ImagePath = "src//img//python.png"
            },
            new()
            {
                Name = "php",
                ImagePath = "src//img//php.png"
            }
        };

        dbContext.Tags.AddRange(tags);
        dbContext.SaveChanges();
    }
}