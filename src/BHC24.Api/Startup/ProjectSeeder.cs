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

        Faker<Project> projectFaker = new Faker<Project>()
            .RuleFor(r => r.Title, f => string.Join(' ', f.Commerce.ProductName()))
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.GithubRepositoryUrl, f => f.Internet.Url())
            .RuleFor(r => r.Tags, f => f.PickRandom(dbContext.Tags.ToList(), f.Random.Number(1, 5)).ToList())
            .RuleFor(r => r.Owner, f => f.PickRandom(dbContext.Users.ToList()).Profile)
            .RuleFor(r => r.CollaboratorsCount, f => f.Random.Number(1, 35))
            .RuleFor(r => r.Collaborators, f => f.PickRandom(dbContext.Users.ToList(), f.Random.Number(1, 15)).ToList());
        
        dbContext.Projects.AddRange(projectFaker.Generate(500));
        dbContext.SaveChanges();
    }
}