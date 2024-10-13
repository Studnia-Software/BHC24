using BHC24.Api.Models;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[Route("api/[controller]")]
[ApiController, AllowAnonymous]
public class TagController : ControllerBase
{
    private readonly BhcDbContext _dbContext;
    
    public TagController(BhcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<Result<List<TagResponse>>> GetTagsAsync(CancellationToken ct)
    {
        var tags = await _dbContext.Tags
            .Select(t => new TagResponse
            {
                Id = t.Id,
                Name = t.Name,
                ImagePath = t.ImagePath
            })
            .ToListAsync(ct);
        
        return Result.Ok(tags);
    }
}