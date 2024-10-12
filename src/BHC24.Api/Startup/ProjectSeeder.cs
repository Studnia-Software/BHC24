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
	        .RuleFor(r => r.Owner, f => dbContext.Users.First());
        
        dbContext.Projects.AddRange(projectFaker.Generate(50));
        dbContext.SaveChanges();
    }
}