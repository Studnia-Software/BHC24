namespace BHC24.Api.Models.Projects;

public record GetProjectResponse
{
    public string Title { get; init; }
    public string Description { get; init; }
    public string Owner { get; init; }
    public IEnumerable<string> Collaborators { get; init; }
}

public record AddProjectRequest(string Title, string Description);