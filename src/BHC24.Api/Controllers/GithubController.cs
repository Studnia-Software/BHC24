using BHC24.Api.Dto.Issues;
using BHC24.Api.Dto.PullRequest;
using BHC24.Api.Models;
using BHC24.Api.Persistence;
using BHC24.Api.Services;
using BHC24.Api.TempStorage;
using GithubClient.Models;
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
    private readonly IssuesListStorage _issuesListStorage;
    private readonly GithubService _githubService;
    private readonly BhcDbContext _dbContext;
    private readonly PrListStorage _prListStorage;
    
    public GithubController(GithubService githubService, CommitListStorage commitListStorage, IssuesListStorage issuesListStorage, BhcDbContext dbContext, PrListStorage prListStorage)
    {
        _githubService = githubService;
        _commitListStorage = commitListStorage;
        _issuesListStorage = issuesListStorage;
        _dbContext = dbContext;
        _prListStorage = prListStorage;
    }
    
    [HttpGet("{projectId}/repo/commits")]
    public async Task<Result<IEnumerable<CommitResponseDto>>> GetCommits([FromRoute] int projectId, CancellationToken ct)
    {
        var project = await _dbContext.Projects
            .Where(p => p.Id == projectId)
            .FirstOrDefaultAsync(ct);
        
        var ghUrl = project.GithubRepositoryUrl;
        var owner = ghUrl.Split('/')[3];
        var repo = ghUrl.Split('/')[4];
        
        var commits = await _githubService.GetCommitListAsync(owner, repo);
        
        var commitList = commits.Select(x => new CommitResponseDto
        {
            Url = x.commit.url,
            CommitAuthorName = x.author.login,
            CommitMessage = x.commit.message
        });
        
        _commitListStorage.Commits.AddRange(commitList);
        
        return Result.Ok(commitList);
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
        
        _commitListStorage.Commits.AddRange(commitList);
        
        return Result.Ok(commitList);
    }
    
    [HttpGet("{projectId}/repo/issues")]
    public async Task<Result> GetIssues([FromRoute] int projectId, CancellationToken ct)
    {
        var project = await _dbContext.Projects
            .Where(p => p.Id == projectId)
            .FirstOrDefaultAsync(ct);
        
        var ghUrl = project.GithubRepositoryUrl;
        var owner = ghUrl.Split('/')[3];
        var repo = ghUrl.Split('/')[4];
        
        var issues = await _githubService.GetIssueListAsync(owner, repo);
        
        var issuesList = issues.Select(x => new IssuesResponseDto
        {
            Title = x.title,
            Body = x.body,
            ClosedAt = x.closed_at,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at
        });
        
        _issuesListStorage.Issues.AddRange(issuesList);
        
        return Result.Ok();
    }
    
    [HttpGet("{url}/repo/issues/test")]
    public async Task<Result<IEnumerable<IssuesResponseDto>>> GetIssues([FromQuery] string url, CancellationToken ct)
    {
        var owner = url.Split('/')[3];
        var repo = url.Split('/')[4];
        
        var issues = await _githubService.GetIssueListAsync(owner, repo);
        
        var issuesList = issues.Select(x => new IssuesResponseDto
        {
            Title = x.title,
            Body = x.body,
            ClosedAt = x.closed_at,
            CreatedAt = x.created_at,
            UpdatedAt = x.updated_at
        });
        
        _issuesListStorage.Issues.AddRange(issuesList);
        
        return Result.Ok(issuesList);
    }
    
    [HttpGet("{projectId}/repo/prs")]
    public async Task<Result<IEnumerable<PrResponse>>> GetPrs([FromRoute] int projectId, CancellationToken ct)
    {
        var project = await _dbContext.Projects
            .Where(p => p.Id == projectId)
            .FirstOrDefaultAsync(ct);
        
        var ghUrl = project.GithubRepositoryUrl;
        var owner = ghUrl.Split('/')[3];
        var repo = ghUrl.Split('/')[4];
        
        var prs = await _githubService.GetPrListAsync(owner, repo);
        
        var response = prs.Select(p => new PrResponse
        {
            Url = p.Url,
            Title = p.Title,
            Body = p.Body,
            ClosedAt = p.ClosedAt,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            MergedAt = p.MergedAt
        });
        
        _prListStorage.PullRequests.AddRange(response);
        
        return Result.Ok(response);
    }
    
    [HttpGet("{url}/repo/prs/test")]
    public async Task<Result<IEnumerable<PrResponse>>> GetPrs([FromQuery] string url, CancellationToken ct)
    {
        var owner = url.Split('/')[3];
        var repo = url.Split('/')[4];
        
        var prs = await _githubService.GetPrListAsync(owner, repo);

        var response = prs.Select(p => new PrResponse
        {
            Url = p.Url,
            Title = p.Title,
            Body = p.Body,
            ClosedAt = p.ClosedAt,
            CreatedAt = p.CreatedAt,
            UpdatedAt = p.UpdatedAt,
            MergedAt = p.MergedAt
        });
        
        _prListStorage.PullRequests.AddRange(response);
        
        return Result.Ok(response);
    }
}