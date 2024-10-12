using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Investors;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InvestorController : ControllerBase
{
    private readonly BhcDbContext _dbContext;

    public InvestorController(BhcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    [HttpGet]
    public async Task<Result<PaginationResponse<GetInvestorResponse>>> GetInvestorsAsync(
        [FromQuery] PaginationRequest request, CancellationToken ct)
    {
        var investors = await _dbContext.Investors
            .Select(i => new GetInvestorResponse
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                CompanyName = i.CompanyName,
                HasPremium = i.HasPremium
            }).PaginateAsync(request, ct);

        return Result.Ok(investors);
    }
  
    [HttpGet ("{investorId}")]
    public async Task<Result<GetInvestorResponse>> GetInvestorAsync(int id, CancellationToken ct)
    {
        var investor = await _dbContext.Investors
            .Select(i => new GetInvestorResponse
            {
                Id = i.Id,
                Name = i.Name,
                Surname = i.Surname,
                Email = i.Email,
                PhoneNumber = i.PhoneNumber,
                CompanyName = i.CompanyName,
                HasPremium = i.HasPremium
            })
            .FirstOrDefaultAsync(i => i.Id == id, ct);

        return Result.Ok(investor);
    }
    
    [HttpPost]
    public async Task<Result> AddInvestorAsync(AddInvestorRequest request, CancellationToken ct)
    {
        var investor = new Investor
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            CompanyName = request.CompanyName,
        };

        _dbContext.Investors.Add(investor);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Ok();
    }


    [HttpDelete("{investorId}")]
    public async Task<Result> DeleteInvestorAsync(int id, CancellationToken ct)
    {
        var investor = await _dbContext.Investors.FirstOrDefaultAsync(i => i.Id == id);        if (investor is null)
        {
            return Result.NotFound();
        }
        
        _dbContext.Investors.Remove(investor);
        await _dbContext.SaveChangesAsync(ct);

        return Result.Ok();
    }
}