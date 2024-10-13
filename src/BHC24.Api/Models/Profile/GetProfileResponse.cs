using BHC24.Api.Models.Projects;
using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Profile;

public class GetProfileResponse
{
    public string? GithubAccountUrl { get; set; }
    public string? LinkedInAccountUrl { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public byte[]? UserCv { get; set; }
    public string? Description { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required string UserName { get; set; }
    public ICollection<TagResponse>? Tags { get; set; }
    public ICollection<GetProjectResponse> Projects { get; set; }
}