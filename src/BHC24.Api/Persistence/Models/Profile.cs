namespace BHC24.Api.Persistence.Models;

public class Profile : BaseTrackingEntity
{
    public string? GithubAccountUrl { get; set; }
    public string? LinkedInAccountUrl { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public byte[]? UserCv { get; set; }
    public string? Description { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}