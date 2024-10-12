using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Profile;

public class CreateProfileRequest
{
    public string? GithubAccountUrl { get; set; }
    public string? LinkedInAccountUrl { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public byte[]? UserCv { get; set; }
    public string? Description { get; set; }
    
    public required Guid AppUserId { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}