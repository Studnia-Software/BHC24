using GithubClient.Interfaces;
using GithubClient.Models;
using GithubClient.Models.CommitResponse;
using Newtonsoft.Json;

namespace BHC24.Api.Services;

public class GithubService
{
    private readonly IGithubClient _client;

    public GithubService(IGithubClient client)
    {
        _client = client;
    }
    
    public async Task<IEnumerable<CommitResponseModel>> GetCommitListAsync(string owner, string repo)
    {
        var data = await _client.GetCommitListAsync(owner, repo);
        Console.WriteLine(JsonConvert.SerializeObject(data.ElementAt(0)));
        return data;
    }
    
    public async Task<IEnumerable<IssuesResponseModel>> GetIssueListAsync(string owner, string repo)
    {
        return await _client.GetIssueListAsync(owner, repo);
    }
}