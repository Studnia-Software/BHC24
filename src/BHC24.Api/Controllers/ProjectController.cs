using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Offer;
using BHC24.Api.Models.Projects;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public async Task<IActionResult> GetList([FromQuery] PaginationRequest request)
    {
        var projects = await _dbContext.Projects
            .Select(p => new GetProjectResponse
            {
                Title = p.Title,
                Description = p.Description,
                Owner = p.Owner.UserName,
                Collaborators = p.Collaborators.Select(c => c.UserName),
            })
            .PaginateAsync(request);
        
        return Ok(projects);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddProjectRequest request)
    {
        var user = await _authUser.GetAsync();
        
        var project = new Project
        {
            Title = request.Title,
            Description = request.Description,
            Owner = user
        };
        
        _dbContext.Projects.Add(project);
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPost("/{projectId}/offer")]
    public async Task<Models.Response> CreateOfferAsync([FromRoute]int projectId, [FromBody]CreateOfferRequest request, CancellationToken ct)
    {
        var offer = new Offer
        {
            Title = request.Title,
            Description = request.Description,
            Collaborators = request.Collaborators,
            Tags = request.Tags,
            ProjectId = request.ProjectId
        };

        await _dbContext.Offers.AddAsync(offer, ct);
        await _dbContext.SaveChangesAsync(ct);

        return new Models.Response();
    } 
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, AddProjectRequest request)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Owner)
            .Include(p => p.Collaborators)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project is null)
        {
            return NotFound();
        }
        
        if (project.Owner.Id != (await _authUser.GetAsync()).Id)
        {
            return Forbid();
        }
        
        project.Title = request.Title;
        project.Description = request.Description;
        
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _dbContext.Projects
            .Include(p => p.Owner)
            .Include(p => p.Collaborators)
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (project == null)
        {
            return NotFound();
        }
        
        if (project.Owner.Id != (await _authUser.GetAsync()).Id)
        {
            return Forbid();
        }
        
        _dbContext.Projects.Remove(project);
        await _dbContext.SaveChangesAsync();
        
        return Ok();
    }
}