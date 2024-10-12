using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Offer;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using BHC24.Api.Models;
using BHC24.Api.Response.Offer;
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
    public async Task<Response<PaginationResponse<GetOfferResponse>>> GetOffersAsync(PaginationRequest request, CancellationToken ct)
    {
        var offers = await _dbContext.Offers
            .Select(o => new GetOfferResponse
            {
                Title = o.Title,
                Description = o.Description,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Collaborators = o.Collaborators,
                Tags = o.Tags,
                Project = o.Project
            }).PaginateAsync(request, ct);

        return new Response<PaginationResponse<GetOfferResponse>>();
    }
    
    [HttpGet("{offerId}")]
    public async Task<GetOfferResponse> GetOfferAsync([FromRoute]int offerId, CancellationToken ct)
    {
        var offer = await _dbContext.Offers
            .Where(o => o.Id == offerId)
            .Select(o => new GetOfferResponse
            {
                Title = o.Title,
                Description = o.Description,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Collaborators = o.Collaborators,
                Tags = o.Tags,
                Project = o.Project
            }).SingleOrDefaultAsync(ct);

        return offer;
    }
    
    [HttpPut("{offerId}")]
    public async Task<IActionResult> UpdateOfferAsync([FromRoute]int offerId, [FromBody]UpdateOfferRequest request, CancellationToken ct)
    {
        var offer = await _dbContext.Offers
            .Where(o => o.Id == offerId)
            .ExecuteUpdateAsync( b =>
                b.SetProperty(o => o.Title, request.Title)
                    .SetProperty(o => o.Collaborators, request.Collaborators)
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