using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Bogus;

namespace BHC24.Api.Startup;

public class UserSeeder
{
    public static void Seed(BhcDbContext dbContext)
    {
        if(dbContext.Users.Any())
        {
            return;
        }

        var users = UserSeeder.GenerateFakeUsers(10, dbContext);
        
        dbContext.Users.AddRange(users);
        dbContext.SaveChanges();
    }
    
	    public static List<AppUser> GenerateFakeUsers(int count, BhcDbContext dbContext)
	    {
		    var tags = dbContext.Tags.ToList();
		    var userFaker = new Faker<AppUser>("pl")
			    .RuleFor(u => u.UserName, f => f.Internet.UserName())
			    .RuleFor(u => u.Name, f => f.Name.FirstName())
			    .RuleFor(u => u.Surname, f => f.Name.LastName())
			    .RuleFor(u => u.Email, f => f.Internet.Email())
			    .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
			    .RuleFor(u => u.PasswordHash, f => f.Internet.Password())
			    .RuleFor(u => u.Profile, f => new Profile
			    {
				    GithubAccountUrl = f.Internet.Url(),
				    LinkedInAccountUrl = f.Internet.Url(),
				    Tags = f.PickRandom(tags, 2).ToList() 
			    });

		    return userFaker.Generate(count);
	    }
}