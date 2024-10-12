using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;

namespace DefaultNamespace;

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
            
        };
    }
}