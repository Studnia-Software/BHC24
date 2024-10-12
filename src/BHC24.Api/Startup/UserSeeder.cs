using Bhc24.Api.Persistence;
using Bhc24.Api.Persistence.Models;

namespace DefaultNamespace;

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
            
        };
    }
}