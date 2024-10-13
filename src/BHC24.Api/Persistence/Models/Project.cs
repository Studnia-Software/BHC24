namespace BHC24.Api.Persistence.Models;

public class Project : BaseTrackingEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string GithubRepositoryUrl { get; set; }
    
    
    public int OwnerId { get; set; }
    public Profile Owner { get; set; }
    public ICollection<AppUser> Collaborators { get; set; } = [];
    public int CollaboratorsCount { get; set; }
    public ICollection<Offer> Offers { get; set; } = [];
    public ICollection<Tag> Tags { get; set; } = [];
}