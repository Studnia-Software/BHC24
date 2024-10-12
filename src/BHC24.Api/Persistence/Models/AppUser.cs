using Microsoft.AspNetCore.Identity; 

namespace BHC24.Api.Persistence.Models;

public class AppUser : IdentityUser<Guid>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public Profile Profile { get; set; }
}