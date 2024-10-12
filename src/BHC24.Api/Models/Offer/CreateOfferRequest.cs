using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Offer;

public class CreateOfferRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<AppUser> Collaborators { get; set; } = [];

    public ICollection<Tag>? Tags { get; set; }
}