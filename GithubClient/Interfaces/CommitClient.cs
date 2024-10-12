using GithubClient.Models;
using GithubClient.Models.CommitResponse;
using Refit;

namespace GithubClient.Interfaces;

public partial interface IGithubClient
{
    [Headers("User-Agent: YourAppName", "Accept: application/vnd.github.v3+json")]
    [Get("/repos/{owner}/{repo}/commits")]
    public Task<IEnumerable<CommitResponseModel>> GetCommitListAsync(string owner, string repo);
}