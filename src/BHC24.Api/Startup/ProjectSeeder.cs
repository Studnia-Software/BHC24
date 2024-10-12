using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Startup;

public class ProjectSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Project.Any())
        {
            return;
        }

        var projects = new Project[]
        {
            new()
            {
                Title = "Project 1",
                Description = "Description 1",
                Owner = dbContext.AppUser.First(),
                Collaborators = new ICollection<AppUser> { dbContext.AppUser.First() }
            },
            new()
            {
                Title = "Project 2",
                Description = "Description 2",
                Owner = dbContext.AppUser.First(),
                Collaborators = new ICollection<AppUser> { dbContext.AppUser.First() }
            },
            new()
            {
                Title = "Project 3",
                Description = "Description 3",
                Owner = dbContext.AppUser.First(),
                Collaborators = new ICollection<AppUser> { dbContext.AppUser.First() }
            }
        };

        dbContext.Project.AddRange(projects);
        dbContext.SaveChanges();
    }
}