using BHC24.Api.Extensions;
using BHC24.Api.Models;
using BHC24.Api.Models.Offer;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using BHC24.Api.Response;
using BHC24.Api.Response.Offer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BHC24.Api.Controllers;

[ApiController]
public class OfferController : Controller
{
    private readonly BhcDbContext _dbContext;

    public OfferController(BhcDbContext dbContext)
    {
        _dbContext = dbContext;
    }

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
    
    public async Task<GetOfferResponse> GetOfferAsync(int offerId, CancellationToken ct)
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
    
    public async Task<Response.Response> CreateOfferAsync([FromRoute]int projectId, [FromBody]CreateOfferRequest request, CancellationToken ct)
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

        return new Response.Response();
    } 
}