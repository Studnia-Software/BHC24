using Bhc24.Api.Persistence;
using Bhc24.Api.Persistence.Models;

namespace Bhc24.Api.Startup;

public class UserSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if(dbContext.AppUsers.Any())
        {
            return;
        }
        
        var users = new AppUser[]
        {
            new()
            {
                UserName = "JohnDoe123", Name = "John", Surname = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789", PaswordHash = "password123",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/JohnDoe123",
                    LinkedInAccountUrl = "https://linkedin.com/in/JohnDoe",
        			Tags = new ICollection<Tags>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "html"),
							dbContext.Tags.FirstOrDefault(t => t.Name == "css")
						}
				}
            },
            new()
            {
                UserName = "JaneSmith456", Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987654321", PaswordHash = "password456",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/JaneSmith456",
                    LinkedInAccountUrl = "https://linkedin.com/in/JaneSmith",
        			Tags = new ICollection<Tags>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "python")
						}
                }
            },
            new()
            {
                UserName = "SamAdams789", Name = "Sam", Surname = "Adams", Email = "sam.adams@example.com", PhoneNumber = "555123456", PaswordHash = "password789",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/SamAdams789",
                    LinkedInAccountUrl = "https://linkedin.com/in/SamAdams",
		          	    Tags = new ICollection<Tags>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "html"),
							dbContext.Tags.FirstOrDefault(t => t.Name == "javascript")
						}
					
                }
            }
        };
        
        dbContext.AppUsers.AddRange(users);
        dbContext.SaveChanges();
    }
}