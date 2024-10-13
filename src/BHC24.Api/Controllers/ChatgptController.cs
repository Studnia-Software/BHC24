using BHC24.Api.Models;
using BHC24.Api.Persistence;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChatgptController
{
    private readonly BhcDbContext _dbContext;
    private readonly ChatgptService _chatgptService;
    
    public ChatgptController(BhcDbContext dbContext, AuthUserProvider authUser, ChatgptService chatgptService)
    {
        _dbContext = dbContext;
        _chatgptService = chatgptService;
    }
    
    [HttpGet]
    public async Task<Result<string>> GenerateSimpleResponseAsync(CancellationToken ct)
    {
        var response = await _chatgptService.GenerateChatResponse("Hello, giive some long answer");
        
        return Result.Ok(response);
    }

    [HttpGet("{projectId}/AI/commit")]
    public async Task<Result<string>> GenerateCommitResponseAsync([FromRoute] int projectId, CancellationToken ct)
    {
        var project = await _dbContext.Projects
            .Where(p => p.Id == projectId)
            .FirstOrDefaultAsync(ct);

        var response = await _chatgptService.AnalyzeCommit(project.GithubRepositoryUrl);
        
        return Result.Ok(response);
        ;
    }
}