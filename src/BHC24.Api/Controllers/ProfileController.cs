using BHC24.Api.Models;
using BHC24.Api.Models.Profile;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly BhcDbContext _dbContext;
    private readonly AuthUserProvider _authUser;

    public ProfileController(BhcDbContext dbContext, AuthUserProvider authUser)
    {
        _dbContext = dbContext;
        _authUser = authUser;
    }
    
    [HttpGet("{userId}")]
    public async Task<Result<GetProfileResponse>> GetProfileAsync([FromRoute] Guid userId, CancellationToken ct)
    {
        var profile = await _dbContext.Profiles
            .Where(p => p.AppUserId == userId)
            .Select(x => new GetProfileResponse
            {
                GithubAccountUrl = x.GithubAccountUrl,
                LinkedInAccountUrl = x.LinkedInAccountUrl,
                ProfilePicture = x.ProfilePicture,
                UserCv = x.UserCv,
                Description = x.Description,
                AppUser = x.AppUser,
                Tags = x.Tags
            }).FirstOrDefaultAsync(ct);

        if (profile.AppUser.Id != (await _authUser.GetAsync()).Id)
        {
            return Result<GetProfileResponse>.Forbidden<GetProfileResponse>("Forbidden");
        }
        
        return Result.Ok(profile);
    }
    
    [HttpPost("/create")]
    public async Task<Result> CreateProfileAsync([FromBody] CreateProfileRequest request, CancellationToken ct)
    {
        var user = await _authUser.GetAsync();
        
        var profile = new Profile
        {
            GithubAccountUrl = request.GithubAccountUrl,
            LinkedInAccountUrl = request.LinkedInAccountUrl,
            ProfilePicture = request.ProfilePicture,
            UserCv = request.UserCv,
            Description = request.Description,
            AppUserId = user.Id,
            Tags = request.Tags
        };
        
        _dbContext.Profiles.Add(profile);
        await _dbContext.SaveChangesAsync(ct);
        
        return Result.Ok();
    }
    
    [HttpPut("{userId}")]
    public async Task<Result> UpdateProfileAsync([FromRoute] Guid userId, [FromBody] UpdateProfileRequest request, CancellationToken ct)
    {
        if (userId != (await _authUser.GetAsync()).Id)
        {
            return Result.Forbidden();
        }

        var tagsToAdd = new List<Tag>();
        tagsToAdd.AddRange(request.Tags);
        
        var all_tags = await _dbContext.Profiles.Where(x => x.AppUserId == userId).SelectMany(x => x.Tags).ToListAsync(ct);
        
        tagsToAdd.AddRange(all_tags);
        
        var profile = await _dbContext.Profiles
            .Where(p => p.AppUserId == userId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(p => p.GithubAccountUrl, request.GithubAccountUrl)
                    .SetProperty(p => p.LinkedInAccountUrl, request.LinkedInAccountUrl)
                    .SetProperty(p => p.ProfilePicture, request.ProfilePicture)
                    .SetProperty(p => p.UserCv, request.UserCv)
                    .SetProperty(p => p.Description, request.Description)
                    .SetProperty(p => p.Tags, tagsToAdd.Distinct()), ct);
        
        return Result.Ok();
    }
    
    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteProfileAsync([FromRoute] Guid userId, CancellationToken ct)
    {
        if (userId != (await _authUser.GetAsync()).Id)
        {
            return Forbid();
        }

        var profile = await _dbContext.Profiles
            .Where(p => p.AppUserId == userId)
            .SingleOrDefaultAsync(ct);
        
        if (profile == null)
        {
            return NotFound();
        }
        
        _dbContext.Profiles.Remove(profile);
        await _dbContext.SaveChangesAsync(ct);
        
        return Ok();
    }
}