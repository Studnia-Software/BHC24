using Microsoft.AspNetCore.Identity;

namespace BHC24.Api.Persistence.Models;

public class AppUser : IdentityUser<Guid>
{
    public ICollection<Tag>? Tags { get; set; }
}