using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Startup;

public class UserSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if(dbContext.Users.Any())
        {
            return;
        }
        
        var users = new AppUser[]
        {
            new()
            {
                UserName = "JohnDoe123",
                Name = "John", Surname = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "123456789",
                PasswordHash = "password123",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/JohnDoe123",
                    LinkedInAccountUrl = "https://linkedin.com/in/JohnDoe",
        			Tags = new List<Tag>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "html"),
							dbContext.Tags.FirstOrDefault(t => t.Name == "css")
						}
				}
            },
            new()
            {
                UserName = "JaneSmith456",
                Name = "Jane", Surname = "Smith",
                Email = "jane.smith@example.com",
                PhoneNumber = "987654321",
                PasswordHash = "password456",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/JaneSmith456",
                    LinkedInAccountUrl = "https://linkedin.com/in/JaneSmith",
        			Tags = new List<Tag>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "python")
						}
                }
            },
            new()
            {
                UserName = "SamAdams789",
                Name = "Sam", Surname = "Adams",
                Email = "sam.adams@example.com",
                PhoneNumber = "555123456", 
                PasswordHash = "password789",
                Profile = new Profile()
                {
                    GithubAccountUrl = "https://github.com/SamAdams789",
                    LinkedInAccountUrl = "https://linkedin.com/in/SamAdams",
		          	    Tags = new List<Tag>
						{
							 dbContext.Tags.FirstOrDefault(t => t.Name == "html"),
							dbContext.Tags.FirstOrDefault(t => t.Name == "javascript")
						}
					
                }
            }
        };
        
        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();
    }
}