using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Startup;

public class ProjectSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if (dbContext.Projects.Any())
        {
            return;
        }

        var projects = new List<Project> { };
        
        projects.Add(
	        new()
	        {
		        Title = "Project 1",
		        Description = "Description 1",
		        GithubRepositoryUrl = "SomeghURl",
		        Owner = dbContext.Users.First(),
		        Collaborators = new List<AppUser> { dbContext.Users.First() },
		        Offers = new List<Offer>{}
	        });
        
			projects[projects.Count-1].Offers.Add(
				new Offer 
				{ 
					Title = "Offer 1",
					Description = "Description 1",
					ProjectId = projects[projects.Count-1].Id,
					Tags = new List<Tag> 
					{ 
						dbContext.Tags.FirstOrDefault(t => t.Name == "python") 
					}
				});
				
				projects.Add(
						new()
						{
							Title = "Project 2",
							Description = "Description 2",
							GithubRepositoryUrl = "SomeghURl2",
							Owner = dbContext.Users.First(),
							Collaborators = new List<AppUser> { dbContext.Users.First() },
							Offers = new List<Offer>{ }
							
						});
				projects[projects.Count - 1].Offers.Add(
					new Offer 
					{ 
						Title = "Offer 2",
						Description = "Description 2",
						ProjectId = projects[projects.Count - 1].Id,
						Tags = new List<Tag> 
						{ 
							dbContext.Tags.FirstOrDefault(t => t.Name == "html"), 
							dbContext.Tags.FirstOrDefault(t => t.Name == "css") 
						}
					} );
				
				projects.Add(           
					new()
				{
					Title = "Project 3",
					Description = "Description 3",
					GithubRepositoryUrl = "SomeghURl",
					Owner = dbContext.Users.First(),
					Collaborators = new List<AppUser> { dbContext.Users.First() },
					Offers = new List<Offer>{ }
				});

				projects[projects.Count - 1].Offers.Add(
					new Offer
					{
						Title = "Offer 3",
						Description = "Description 3",
						ProjectId = projects[projects.Count - 1].Id,
						Tags = new List<Tag>
						{
							dbContext.Tags.FirstOrDefault(t => t.Name == "html")
						}
					});
				projects[projects.Count - 1].Offers.Add(
					new Offer
					{
						Title = "Offer 4",
						Description = "Description 4",
						ProjectId = projects[projects.Count - 1].Id,
						Tags = new List<Tag>
						{
							dbContext.Tags.FirstOrDefault(t => t.Name == "javascript")
						}
					});
 
        dbContext.Projects.AddRange(projects);
        dbContext.SaveChanges();
    }
}