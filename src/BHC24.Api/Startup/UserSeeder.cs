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
                new Profile()
                {
                    GithubAccountUrl = "https://github.com/JohnDoe123",
                    LinkedInAccountUrl = "https://linkedin.com/in/JohnDoe"
                }
            },
            new()
            {
                UserName = "JaneSmith456", Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987654321", PaswordHash = "password456",
                new Profile()
                {
                    GithubAccountUrl = "https://github.com/JaneSmith456",
                    LinkedInAccountUrl = "https://linkedin.com/in/JaneSmith"
                }
            },
            new()
            {
                UserName = "SamAdams789", Name = "Sam", Surname = "Adams", Email = "sam.adams@example.com", PhoneNumber = "555123456", PaswordHash = "password789",
                new Profile()
                {
                    GithubAccountUrl = "https://github.com/SamAdams789",
                    LinkedInAccountUrl = "https://linkedin.com/in/SamAdams"
                }
            }
        };
        
        dbContext.AppUsers.AddRange(users);
        dbContext.SaveChanges();
    }
}