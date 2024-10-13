using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Projects;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SearchController
{
    private readonly BhcDbContext _dbContext;
    
    public SearchController(BhcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet("projectByName")]
    public async Task<Result<PaginationResponse<GetProjectResponse>>> SearchProjects(
        [FromQuery] string projectName, 
        [FromQuery] string? tagNames,
        [FromQuery] string? ownerName,
        [FromQuery] PaginationRequest pagination, 
        CancellationToken ct)
    {
        IQueryable<Project> projects = _dbContext.Projects;
        
        if(!string.IsNullOrEmpty(projectName))
        {
            projects = projects.Where(p => p.Title.ToLower().Contains(projectName.ToLower()));
        }
        
        if(!string.IsNullOrEmpty(tagNames))
        {
            var splitTagNames = tagNames.Split(',');
            projects = projects.Where(p => p.Tags.Any(t => splitTagNames.Contains(t.Name)));
        }
        
        if(!string.IsNullOrEmpty(ownerName))
        {
            projects = projects.Where(p => p.Owner.AppUser.UserName.ToLower().Contains(ownerName.ToLower()));
        }
        
        var paginatedProjects = await projects
           .Select(p => new GetProjectResponse
           {
                Title = p.Title,
                Description = p.Description,
                Owner = p.Owner.AppUser.Name,
                OwnerId = p.Owner.AppUserId,
                GithubUrl = p.GithubRepositoryUrl,
                Tags = p.Tags.Select(t => new TagResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    ImagePath = t.ImagePath
                }),
                CollaboratorsCount = p.CollaboratorsCount
           })
           .OrderBy(p => p.Title.Length - projectName.Length)
           .PaginateAsync(pagination, ct);

       return Result.Ok(paginatedProjects);
    }
}