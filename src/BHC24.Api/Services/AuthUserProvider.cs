using System.Security.Claims;
using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Identity;

namespace BHC24.Api.Services;

public class AuthUserProvider
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthUserProvider(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AppUser> GetAsync()
    {
        string? userEmail = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userEmail))
        {
            throw new InvalidOperationException("User is not authenticated");
        }

        AppUser? user = await _userManager.FindByEmailAsync(userEmail);
        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }

        return user;
    }
}