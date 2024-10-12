using BHC24.Api.Models;
using BHC24.Api.Persistence;
using BHC24.Api.Services;
using BHC24.Api.TempStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class GithubController
{
    private readonly CommitListStorage _commitListStorage;
    private readonly GithubService _githubService;
    private readonly BhcDbContext _dbContext;
    
    public GithubController(GithubService githubService, CommitListStorage commitListStorage)
    {
        _githubService = githubService;
        _commitListStorage = commitListStorage;
    }
    
    [HttpGet("{projectId}/repo/commits")]
    public async Task<Result> GetCommits([FromRoute] int projectId, CancellationToken ct)
    {
        var project = await _dbContext.Projects
            .Where(p => p.Id == projectId)
            .FirstOrDefaultAsync(ct);
        
        var ghUrl = project.GithubRepositoryUrl;
        var owner = ghUrl.Split('/')[3];
        var repo = ghUrl.Split('/')[4];
        
        var commits = await _githubService.GetCommitListAsync( owner, repo);
        
        _commitListStorage.Commits = commits.Select(x => new CommitResponseDto
        {
            Url = x.commit.url,
            CommitAuthorName = x.author.login,
            CommitMessage = x.commit.message
        });
        
        return Result.Ok();
    }
    
    [HttpGet("{url}/repo/commits/test")]
    public async Task<Result<IEnumerable<CommitResponseDto>>> GetCommits([FromQuery] string url, CancellationToken ct)
    {
        var owner = url.Split('/')[3];
        var repo = url.Split('/')[4];
        
        Console.WriteLine(url);
        Console.WriteLine(owner);
        Console.WriteLine(repo);
        
        var commits = await _githubService.GetCommitListAsync(owner, repo);
        
        var commitList = commits.Select(x => new CommitResponseDto
        {
            Url = x.commit.url,
            CommitAuthorName = x.author.login,
            CommitMessage = x.commit.message
        });
        
        
        return Result.Ok(commitList);
    }
}