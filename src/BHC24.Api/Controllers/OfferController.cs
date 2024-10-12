using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Offer;
using BHC24.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController : ControllerBase
{
    private readonly BhcDbContext _dbContext;

    public OfferController(BhcDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<Result<PaginationResponse<GetOfferResponse>>> GetOffersAsync([FromQuery] PaginationRequest request, CancellationToken ct)
    {
        var offers = await _dbContext.Offers
            .Select(o => new GetOfferResponse
            {
                Id = o.Id,
                Title = o.Title,
                Description = o.Description,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Tags = o.Tags,
                Project = o.Project
            }).PaginateAsync(request, ct);

        return Result.Ok(offers);
    }
    
    [HttpGet("{offerId}")]
    public async Task<Result<GetOfferResponse>> GetOfferAsync([FromRoute]int offerId, CancellationToken ct)
    {
        var offer = await _dbContext.Offers
            .Where(o => o.Id == offerId)
            .Select(o => new GetOfferResponse
            {
                Id = o.Id,
                Title = o.Title,
                Description = o.Description,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Tags = o.Tags,
                Project = o.Project
            }).FirstOrDefaultAsync(ct);

        return Result.Ok(offer);
    }
    
    [HttpPut("{offerId}")]
    public async Task<IActionResult> UpdateOfferAsync([FromRoute]int offerId, [FromBody]UpdateOfferRequest request, CancellationToken ct)
    {
        var offer = await _dbContext.Offers
            .Where(o => o.Id == offerId)
            .ExecuteUpdateAsync( b =>
                b.SetProperty(o => o.Title, request.Title)
                    .SetProperty(o => o.Tags, request.Tags));
        
        return Ok();
    }
    
    [HttpDelete("{offerId}")]
    public async Task<IActionResult> DeleteOfferAsync([FromRoute]int offerId, CancellationToken ct)
    {
        var offer = await _dbContext.Offers
            .Where(o => o.Id == offerId)
            .SingleOrDefaultAsync(ct);
        
        if (offer == null)
        {
            return NotFound();
        }
        
        _dbContext.Offers.Remove(offer);
        await _dbContext.SaveChangesAsync(ct);
        
        return Ok();
    }
}