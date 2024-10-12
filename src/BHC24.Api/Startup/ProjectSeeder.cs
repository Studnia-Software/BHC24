using BHC24.Api.Persistence;

namespace BHC24.Api.Startup;

public class ProjectSeeder
{
        if(dbContext.Project.Any())
        {
            return;
        }
    
        var projects = new List<Project>
        {
            new Project
            {
                Title = "Project 1",
                Description = "Description 1",
                Owner = dbContext.AppUser.First(),
                Collaborators = new List<AppUser> { dbContext.AppUser.First() }
            },
            new Project
            {
                Title = "Project 2",
                Description = "Description 2",
                Owner = dbContext.AppUser.First(),
                Collaborators = new List<AppUser> { dbContext.AppUser.First() }
            },
            new Project
            {
                Title = "Project 3",
                Description = "Description 3",
                Owner = dbContext.AppUser.First(),
                Collaborators = new List<AppUser> { dbContext.AppUser.First() }
            }
        };
}