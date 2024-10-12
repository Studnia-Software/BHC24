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
				Offers = new ICollection<Offer> 
				{ 
						new Offer 
								{ 
									Title = "Offer 1",
									Description = "Description 1",
									Tags = new ICollection<Tag> 
										{ 
												 dbContext.Tags.FirstOrDefault(t => t.Name == "python") 
										}
								}
				}
            },
            new()
            {
                Title = "Project 2",
                Description = "Description 2",
                Owner = dbContext.AppUser.First(),
                Collaborators = new ICollection<AppUser> { dbContext.AppUser.First() }
            	Offers = new ICollection<Offer> 
				{ 
						new Offer 
								{ 
									Title = "Offer 2",
									Description = "Description 2",
									Tags = new ICollection<Tag> 
										{ 
												 dbContext.Tags.FirstOrDefault(t => t.Name == "html"), 
												 dbContext.Tags.FirstOrDefault(t => t.Name == "css") 
								        }
								} 
				}
			},
            new()
            {
                Title = "Project 3",
                Description = "Description 3",
                Owner = dbContext.AppUser.First(),
                Collaborators = new ICollection<AppUser> { dbContext.AppUser.First() }
            	 Offers = new ICollection<Offer> 
				{ 
						new Offer 
								{ 
									Title = "Offer 3",
									Description = "Description 3",
									Tags = new ICollection<Tag> 
										{ 
												 dbContext.Tags.FirstOrDefault(t => t.Name == "html")
										} 
								},
						new Offer 
						{ 
									Title = "Offer 4",
									Description = "Description 4",
									Tags = new ICollection<Tag> 
										{ 
												 dbContext.Tags.FirstOrDefault(t => t.Name == "javascript")
										} 
							}
				}
			}
        };

        dbContext.Project.AddRange(projects);
        dbContext.SaveChanges();
    }
}