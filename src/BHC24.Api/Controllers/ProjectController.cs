using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Offer;
using BHC24.Api.Models.Projects;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly BhcDbContext _dbContext;
    private readonly AuthUserProvider _authUser;
    
    public ProjectController(BhcDbContext dbContext, AuthUserProvider authUser)
    {
        _dbContext = dbContext;
        _authUser = authUser;
    }
    
    [HttpGet, AllowAnonymous]
    public async Task<Result<PaginationResponse<GetProjectResponse>>> GetList([FromQuery] PaginationRequest request)
    {
        var projects = await _dbContext.Projects
            .Select(p => new GetProjectResponse
            {
                Title = p.Title,
                Description = p.Description,
                Owner = p.Owner.AppUser.UserName,
                OwnerId = p.Owner.AppUserId,
                GithubUrl = p.GithubRepositoryUrl,
                CollaboratorsCount = p.CollaboratorsCount,
                Tags = p.Tags.Select(t => new TagResponse
                {
                    Id = t.Id, 
                    Name = t.Name, 
                    ImagePath = t.ImagePath
                })
            })
            .PaginateAsync(request);
        
        return Result.Ok(projects);
    }
    
    [HttpPost]
    public async Task<Result> Add(AddProjectRequest request)
    {
        var user = await _authUser.GetAsync();
        
        var project = new Project
        {
            Title = request.Title,
            Description = request.Description,
            GithubRepositoryUrl = request.GithubUrl,
            Owner = user.Profile
        };
        
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();

        return Result.Ok();
    }
    
    [HttpPost("/{projectId}/offer")]
    public async Task<Result> CreateOfferAsync([FromRoute] int projectId, [FromBody]CreateOfferRequest request, CancellationToken ct)
    {
        var offer = new Offer
        {
            Title = request.Title,
            Description = request.Description,
            Tags = request.Tags,
            ProjectId = projectId
        };

        await _dbContext.Offers.AddAsync(offer, ct);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Ok();
    } 
    
    [HttpPut("{id}")]
    public async Task<Result> Update(int id, AddProjectRequest request)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Owner)
            .Include(p => p.Collaborators)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project is null)
        {
            return Result.NotFound();
        }
        
        if (project.Owner.AppUserId != (await _authUser.GetAsync()).Id)
        {
            return Result.Fail("You are not the owner of this project");
        }
        
        project.Title = request.Title;
        project.Description = request.Description;
        
        await _dbContext.SaveChangesAsync();

        return Result.Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<Result> Delete(int id)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Owner)
            .Include(p => p.Collaborators)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project == null)
        {
            return Result.NotFound();
        }
        
        if (project.Owner.AppUserId != (await _authUser.GetAsync()).Id)
        {
            return Result.Fail("You are not the owner of this project");
        }
        
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();

        return Result.Ok();
    }
}