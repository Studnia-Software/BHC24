using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Bogus;

namespace BHC24.Api.Startup;

public class ProjectSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Projects.Any())
        {
            return;
        }

        Project project = new Project
        {
            Title = "BHC24",
            Description = "BHC24 is a project management tool for developers",
            GithubRepositoryUrl = "https://github.com/kollibroman/MangaLibrary",
            Owner = dbContext.Users.First(),
            Collaborators = dbContext.Users.Take(5).ToList()
        };
        
        dbContext.Projects.Add(project);
        
        Faker<Project> projectFaker = new Faker<Project>()
            .RuleFor(r => r.Title, f => string.Join(' ', f.Commerce.ProductName()))
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.GithubRepositoryUrl, f => f.Internet.Url())
            .RuleFor(r => r.Owner, f => f.PickRandom(dbContext.Users.ToList()))
            .RuleFor(r => r.Collaborators, f => f.PickRandom(dbContext.Users.ToList(), f.Random.Number(1, 15)).ToList());
        
        dbContext.Projects.AddRange(projectFaker.Generate(10));
        dbContext.SaveChanges();
    }
}