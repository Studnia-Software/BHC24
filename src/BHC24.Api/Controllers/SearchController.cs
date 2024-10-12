using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Projects;
using BHC24.Api.Persistence;
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
    
    [HttpGet("searchProjectByName")]
    public async Task<Result<GetProjectResponse>> SearchProjectNameAsync([FromQuery]string projectName, CancellationToken ct)
    {
       var project = await _dbContext.Projects
           .Where(x => x.Title == projectName)
           .Select(p => new GetProjectResponse
           {
                Title = p.Title,
                Description = p.Description,
                Owner = p.Owner.Name,
                Tags = p.Tags,
                Collaborators = p.Collaborators
           })
           .FirstOrDefaultAsync(ct);

       if (project is not null)
       {
           return Result.Ok<GetProjectResponse>(project);
       }

       return Result<GetProjectResponse>.NotFound("Project not found");
    }
    
    [HttpGet("searchProjectsByTags")]
    public async Task<Result<PaginationResponse<GetProjectResponse>>> SearchProjectByTagsAsync([FromQuery] PaginationRequest request, 
        [FromQuery] string[] tagNames, CancellationToken ct)
    {
        var projects = await _dbContext.Projects.Where(p => p.Tags.Any(t => tagNames.Contains(t.Name)))
            .Select(p => new GetProjectResponse
            {
                Title = p.Title,
                Description = p.Description,
                Owner = p.Owner.Name,
                GithubUrl = p.GithubRepositoryUrl,
                Tags = p.Tags,
                Collaborators = p.Collaborators
            })
            .PaginateAsync(request, ct);
        
        if(projects.TotalCount == 0)
        {
            return Result<PaginationResponse<GetProjectResponse>>.NotFound("No projects found");
        }
        
        return Result.Ok(projects);
    }
}