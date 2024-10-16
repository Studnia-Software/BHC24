using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Projects;

public record GetProjectResponse
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Owner { get; init; }
    public Guid OwnerId { get; init; }
    public string GithubUrl { get; init; }
    public int CollaboratorsCount { get; init; }
    public IEnumerable<TagResponse> Tags { get; init; }
}

public record AddProjectRequest(string Title, string Description, string GithubUrl);