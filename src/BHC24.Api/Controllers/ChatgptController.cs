using BHC24.Api.Models;
using BHC24.Api.Persistence;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BHC24.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ChatgptController
{
    private readonly BhcDbContext _dbContext;
    
    public ChatgptController(BhcDbContext dbContext, AuthUserProvider authUser)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<Result<string>> GenerateSimpleResponseAsync(CancellationToken ct)
    {
        var chatgptService = new ChatgptService();
        var response = await chatgptService.GenerateChatResponse("Hello, how are you?");
        
        return Result.Ok(response);
    }
}