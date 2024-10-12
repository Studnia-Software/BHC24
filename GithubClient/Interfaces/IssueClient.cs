using GithubClient.Models;
using Refit;

namespace GithubClient.Interfaces;

public partial interface IGithubClient
{
    [Headers("User-Agent: YourAppName", "Accept: application/vnd.github.v3+json")]
    [Get("/repos/{owner}/{repo}/issues")]
    public Task<IEnumerable<IssuesResponseModel>> GetIssueListAsync(string owner, string repo);
}