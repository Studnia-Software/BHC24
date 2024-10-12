using BHC24.Api.Persistence.Models;
using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Investors;
using BHC24.Api.Models.Users;
using BHC24.Api.Persistence;
using BHC24.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    private readonly BhcDbContext _dbContext;
    private readonly AuthUserProvider _authUser;
    
    public UserController(BhcDbContext dbContext, AuthUserProvider authUser)
    {
        _dbContext = dbContext;
        _authUser = authUser;
    }
    
    [HttpGet]
    public async Task<Result<PaginationResponse<GetUserResponse>>> GetUsersAsync(
        [FromQuery] PaginationRequest request, CancellationToken ct)
    {
        var users = await _dbContext.Users
            .Include(u => u.Profile) // Ensure Profile is included
            .Select(i => new GetUserResponse
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Profile = i.Profile
            }).PaginateAsync(request, ct);
        
        return Result.Ok(users);
    }
    
    [HttpGet("{userId}")]
    public async Task<Result<GetUserResponse>> GetUserAsync(Guid userId, CancellationToken ct)
    {
        var user = await _dbContext.Users
            .Select(i => new GetUserResponse
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                Profile = i.Profile
            })
            .FirstOrDefaultAsync(i => i.Id == userId, ct);
        
        return Result.Ok(user);
    }
}