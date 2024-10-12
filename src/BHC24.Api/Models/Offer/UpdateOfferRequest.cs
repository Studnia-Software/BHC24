using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Offer;

public class UpdateOfferRequest
{
    public required string Title { get; set; }

    public ICollection<Tag>? Tags { get; set; }
}