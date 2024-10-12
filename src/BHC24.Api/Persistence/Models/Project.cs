namespace BHC24.Api.Persistence.Models;

public class Project : BaseTrackingEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required AppUser Owner { get; set; }
    public ICollection<AppUser> Collaborators { get; set; } = [];
}